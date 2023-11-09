using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKin : Enemy
{
    [Header("Enemy Property")]
    Rigidbody2D rb;
    Collider2D coll;
    Animator enemyAnim;

    float attackTimer = 0f;

    Transform playertrans;

    [Header("Gun Property")]
    //[SerializeField] GameObject gunPrefab;
    [SerializeField] GameObject muzzle;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject gunPivot;
    [SerializeField] Vector2 muzzleDirection;
    Vector2 target;
    float angle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();

        playertrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    // 정의할 상태 열거형(Enum)
    public enum EnemyState
    {
        Idle,
        Chasing,
        Attacking,
        Dead
    }

    private EnemyState currentState = EnemyState.Idle;

    private void Update()
    {
        attackTimer += Time.deltaTime;
        Debug.Log(attackTimer);

        if (health <= 0)
            Die();
        distance = Vector3.Distance(playertrans.position, this.transform.position);

        FollowPlayer();
        if (distance <= moveRange) StartChasing();
        else ChangeState(EnemyState.Idle);

        if (attackTimer > attackCooldown) attackTimer = attackCooldown;
        if (currentState == EnemyState.Chasing && attackTimer == attackCooldown)
            StartAttacking();

        switch (currentState)
        {
            case EnemyState.Idle:
                Debug.Log("Idle");
                UpdateIdleState();
                break;

            case EnemyState.Chasing:
                Debug.Log("Chasing");
                UpdateChasingState();
                break;

            case EnemyState.Attacking:
                Debug.Log("Attacking");
                StartCoroutine(UpdateAttackingState());
                break;

            case EnemyState.Dead:
                enemyAnim.SetTrigger("Die");
                //GameOver씬으로 이동
                break;
        }
    }

    private void UpdateIdleState()
    {
        enemyAnim.SetBool("isWalking", false);

        //idle 상태에서는 정지
        rb.velocity = Vector2.zero;
    }

    private void UpdateChasingState()
    {
        enemyAnim.SetBool("isWalking", true);

        Vector2 playerDir = playertrans.position - rb.transform.position;
        Vector2 nextVec = playerDir.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
        rb.velocity = Vector2.zero;
    }

    IEnumerator UpdateAttackingState()
    {
        rb.velocity = Vector2.zero;

        //enemyAnim.SetBool("isShooting", true);
        Shooting();
        attackTimer = 0f;

        while (attackTimer < attackCooldown)
        {
            attackTimer += Time.deltaTime;
            yield return null;
        }

        attackTimer = 0f;
        //enemyAnim.SetBool("isShooting", true);

        yield return new WaitForSeconds(attackCooldown);
    }

    public void ChangeState(EnemyState newState)
    {
        currentState = newState;
    }

    public void StartChasing()
    {
        ChangeState(EnemyState.Chasing);
    }

    public void StartAttacking()
    {
        ChangeState(EnemyState.Attacking);
    }

    public void Die()
    {
        ChangeState(EnemyState.Dead);
    }

    void FollowPlayer() //조준
    {
        // 몬스터의 위치에서 플레이어의 위치를 향하는 벡터를 계산
        Vector3 directionToPlayer = playertrans.position - gunPivot.transform.position;

        float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        gunPivot.transform.rotation = Quaternion.AngleAxis(angleToPlayer, Vector3.forward);
    }

    void Shooting()
    {
        muzzleDirection = muzzle.transform.right;

        /*
        GameObject _bullet = BulletPooler.Instance.GetBullet(BulletOwner.PLAYER);
        _bullet.transform.position = muzzle.transform.position;
        _bullet.GetComponent<Bullet>().SetDirection(muzzleDirection);
        _bullet.SetActive(true);
        */
    }
}
