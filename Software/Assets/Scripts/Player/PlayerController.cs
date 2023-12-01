using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : PlayerSpecification
{
    [Header("Player Contorol Property")]
    Rigidbody2D playerRigidbody;
    SpriteRenderer spritecompo;
    Animator playerAnim;
    Inven inven;
    Vector3 mouse;

    float damagedCool = 2f;
    float damagedTimer = 0f;
    bool damagedCheck = false;
    

    [Header("Slide Property")]
    Vector2 slideDirection;
    [SerializeField]float slideSpeed = 5f;
    float slideDuration = 0.5f;
    float slideCooldown = 0.5f;
    float slideTimer = 0f;
    bool isSlide = false;

    [Header("Inventory Property")]
    [SerializeField] float holdTime = 1.0f;
    bool isKeyPressed = false;
    float pressTime = 0.0f;
    [SerializeField] float loadTime = 2.0f;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        spritecompo = GetComponent<SpriteRenderer>();
        inven = GetComponent<Inven>();
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            playerRigidbody.velocity = Vector2.zero;
            Die();
        }
        
        if (currentHP > 0)
        {
            FollowMouse();
            PlayerMove();

            ItemThrow();
            ItemSwap();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                inven.UseAcitve();
            }

            /*
            if (Input.GetMouseButtonDown(0))
            {
                Shooting();
            }
            */
        }  
    }

    public void PlayerMove()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if(inputX == 0 && inputY == 0) playerAnim.SetBool("isWalking", false);
        else playerAnim.SetBool("isWalking", true);

        if (inputX < 0) spritecompo.flipX = true;
        else spritecompo.flipX = false;

        Vector2 playerVelocity = new Vector2(inputX, inputY);
        //playerVelocity.Normalize();

        // Player Move
        playerRigidbody.velocity = playerVelocity * speed;

        if (Input.GetMouseButtonDown(1) && !isSlide)
        {
            if (Mathf.Abs(inputX) > 0.1f || Mathf.Abs(inputY) > 0.1f)
            {
                slideDirection = playerVelocity.normalized;

                StartCoroutine(Slide());
            }
        }
    }

    void FollowMouse() //CrossHair
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 calc = mouse - this.transform.position;

        float angle = Mathf.Atan2(calc.y, calc.x) * Mathf.Rad2Deg;
        gunPivot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
        GameObject _projectile = ProjectilePooler.Instance.GetProjectile(ProjectileType.HOMING);
        _projectile.GetComponent<HomingProjectile>().SetProjectileProperty("YariLauncher", 1, 10, 40, 0, 0, 0, muzzleDirection);
        _projectile.transform.position = muzzle.transform.position;
        _projectile.gameObject.SetActive(true);

    }

    void ItemThrow()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G))
        {
            isKeyPressed = true;
            pressTime = 0.0f;
            Debug.Log("Key Pressed!!!");
        }

        if (isKeyPressed && Input.GetKey(KeyCode.F))
        {
            pressTime += Time.deltaTime;
            if (pressTime >= holdTime)
            {
                inven.ThrowWeapon();
                isKeyPressed = false;
                pressTime = 0.0f;
                Debug.Log("Item Throw");
            }
        }

        if (isKeyPressed && Input.GetKey(KeyCode.G))
        {
            pressTime += Time.deltaTime;
            if (pressTime >= holdTime)
            {
                inven.ThrowActive();
                isKeyPressed = false;
                Debug.Log("Item Throw");
            }
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            isKeyPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            isKeyPressed = false;
        }
    }

    void ItemSwap()
    {
        float wheelMove = Input.GetAxis("Mouse ScrollWheel");
        if (wheelMove != 0)
        {
            inven.SwapWeapon(wheelMove);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            inven.SwapActive();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EndTrigger"))
        {
            GameObject.Find("MapManager").GetComponent<MapManager>().RemoveEndPoint();
        }
        else if (collision.CompareTag("Floor"))
        {
            collision.transform.GetChild(0).gameObject.GetComponent<Spawner>().SpawmEnemies();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("StartTrigger"))
        {
            GameObject.Find("MapManager").GetComponent<MapManager>().RemoveStartPoint();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isSlide && !damagedCheck && currentHP > 0)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                float getDamage = collision.gameObject.GetComponent<Enemy>().damage;
                currentHP -= getDamage;

                damagedCheck = true;
                StartCoroutine(DamageEffect());
            }
            else if (collision.gameObject.tag == "EnemyBullet")
            {

            }
        }
    }

    public void GetDamage(float _damage)
    {
        if(currentHP > 0)
        {
            currentHP -= _damage;
        }
    }

    IEnumerator DamageEffect()
    {
        damagedTimer = 0f;
        while (damagedTimer < damagedCool)
        {
            damagedTimer += Time.deltaTime;

            spritecompo.color = new Color(1, 1, 1, 0.5f);
            yield return null;
            spritecompo.color = new Color(1, 1, 1, 1);
            yield return null;
        }

        damagedCheck = false;
        spritecompo.color = new Color(1, 1, 1, 1);

        yield return null;
    }

    IEnumerator Slide()
    {
        isSlide = true;
        playerAnim.SetBool("isRolling", true);
        slideTimer = 0f;

        while (slideTimer < slideDuration)
        {
            playerRigidbody.velocity = slideDirection * slideSpeed;

            slideTimer += Time.deltaTime;
            yield return null;
        }

        playerRigidbody.velocity = Vector2.zero;
        isSlide = false;
        playerAnim.SetBool("isRolling", false);

        yield return new WaitForSeconds(slideCooldown);
    }

    void Die()
    {
        playerAnim.SetTrigger("Die");
        loadTime -= Time.deltaTime;

        if(loadTime <= 0f) SceneManager.LoadScene(1);

        // Scene Gameover
    }
}
