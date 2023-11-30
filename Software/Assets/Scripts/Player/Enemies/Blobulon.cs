using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TestTools;

public class Blobulon : Enemy
{
    [Header("Enemy Property")]
    Rigidbody2D rb;
    Collider2D coll;
    Animator enemyAnim;
    SpriteRenderer spritecompo;

    bool isAlive = true;
    public Transform spawn1;
    public Transform spawn2;
    public GameObject spawner;
    public bool canDivide;

    Transform playertrans;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();
        spritecompo = GetComponent<SpriteRenderer>();

        playertrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    // ������ ���� ������(Enum)
    public enum EnemyState
    {
        Idle,
        Chasing,
        Dead
    }

    private EnemyState currentState = EnemyState.Idle;

    private void Update()
    {
        if (isAlive)
        {
            if (health <= 0)
                Die();
            distance = Vector3.Distance(playertrans.position, this.transform.position);

            if (rb.transform.position.x < playertrans.position.x)
                spritecompo.flipX = true;
            else spritecompo.flipX = false;

            switch (currentState)
            {
                case EnemyState.Idle:
                    UpdateIdleState();
                    break;

                case EnemyState.Chasing:
                    UpdateChasingState();
                    break;

                case EnemyState.Dead:
                    enemyAnim.SetTrigger("Die");

                    coll.enabled = false;
                    isAlive = false;
                    if (canDivide)
                    {
                        Invoke("SpawnDef", 1f);
                    }

                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health > 0)
        {
            if (collision.gameObject.tag == "PlayerBullet")
            {
                /*
                float getDamage = collision.gameObject.GetComponent<Enemy>().damage;
                health -= getDamage;
                */
                health -= 1;
            }
        }
    }

    void SpawnDef()
    {
        spritecompo.enabled = false;

        GameObject spawner1 = Instantiate(spawner);
        GameObject spawner2 = Instantiate(spawner);

        spawner1.transform.position = spawn1.position;
        spawner2.transform.position = spawn2.position;

        Destroy(this, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            float getDamage = collision.gameObject.GetComponent<Enemy>().damage;
            health -= getDamage;
        }
    }

    private void UpdateIdleState()
    {
        enemyAnim.SetBool("isWalking", false);

        //idle ���¿����� ����
        rb.velocity = Vector2.zero;

        if (distance <= moveRange) StartChasing();
    }

    private void UpdateChasingState()
    {
        enemyAnim.SetBool("isWalking", true);

        Vector2 playerDir = playertrans.position - rb.transform.position;
        Vector2 nextVec = playerDir.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
        rb.velocity = Vector2.zero;
    }

    public void ChangeState(EnemyState newState)
    {
        currentState = newState;
    }

    public void StartChasing()
    {
        ChangeState(EnemyState.Chasing);
    }

    public void Die()
    {
        ChangeState(EnemyState.Dead);
    }
}
