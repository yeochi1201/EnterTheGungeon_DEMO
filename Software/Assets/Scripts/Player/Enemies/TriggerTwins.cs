using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTwins : Enemy
{
    [Header("Enemy Property")]
    Rigidbody2D rb;
    Collider2D coll;
    Animator enemyAnim;
    SpriteRenderer spritecompo;

    float attackTimer = 0f;
    bool isCoroutine = false;
    bool isAlive = true;

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
        spritecompo = GetComponent<SpriteRenderer>();

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
        if (!isCoroutine && isAlive)
        {
            attackTimer += Time.deltaTime;
            Debug.Log(attackTimer);

            if (health <= 0)
                Die();
            distance = Vector3.Distance(playertrans.position, this.transform.position);

            if (rb.transform.position.x < playertrans.position.x)
                spritecompo.flipX = true;
            else spritecompo.flipX = false;

            FollowPlayer();
            if (currentState != EnemyState.Attacking && distance <= moveRange) StartChasing();
            else ChangeState(EnemyState.Idle);

            if (currentState == EnemyState.Chasing && attackTimer >= attackCooldown)
                StartAttacking();

            switch (currentState)
            {
                case EnemyState.Idle:
                    UpdateIdleState();
                    break;

                case EnemyState.Chasing:
                    UpdateChasingState();
                    break;

                case EnemyState.Attacking:
                    StartCoroutine(UpdateAttackingState());
                    break;

                case EnemyState.Dead:
                    enemyAnim.SetTrigger("Die");
                    coll.enabled = false;
                    isAlive = false;
                    break;
            }
        }
    }

    private void UpdateIdleState()
    {
        Debug.Log("Idle");

        enemyAnim.SetBool("isWalking", false);

        //idle 상태에서는 정지
        rb.velocity = Vector2.zero;
    }

    private void UpdateChasingState()
    {
        Debug.Log("Walking");

        enemyAnim.SetBool("isWalking", true);

        Vector2 playerDir = playertrans.position - rb.transform.position;
        Vector2 nextVec = playerDir.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
        rb.velocity = Vector2.zero;
    }

    IEnumerator UpdateAttackingState()
    {
        Debug.Log("Attacking");
        isCoroutine = true;

        rb.velocity = Vector2.zero;

        enemyAnim.SetBool("isShooting", true);
        enemyAnim.SetBool("isWalking", false);

        attackTimer = 0f;

        StartCoroutine(Pattern1());

        yield return null;
    }

    IEnumerator Pattern1(){
        coll.enabled = false;

        while (rb.transform.position == playertrans.position)
        {
            Vector2 playerDir = playertrans.position - rb.transform.position;
            Vector2 nextVec = playerDir.normalized * speed * 3f;
            rb.MovePosition(rb.position + nextVec);
        }
        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(1);

        coll.enabled = true;

        attackTimer = 0f;
        isCoroutine = false;
        enemyAnim.SetBool("isShooting", false);

        yield return null;
    }

    IEnumerator Pattern2(){
        Debug.Log("Attacking");
        isCoroutine = true;

        rb.velocity = Vector2.zero;

        enemyAnim.SetBool("isShooting", true);
        enemyAnim.SetBool("isWalking", false);

        Shooting();
        attackTimer = 0f;

        while (attackTimer < attackCooldown)
        {
            attackTimer += Time.deltaTime;
            yield return null;
        }

        attackTimer = 0f;
        isCoroutine = false;
        enemyAnim.SetBool("isShooting", false);

        yield return null;
    }

    IEnumerator Pattern3(){
        yield return null;
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
