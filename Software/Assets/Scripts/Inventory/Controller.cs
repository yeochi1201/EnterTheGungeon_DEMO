using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Controller : PlayerSpecification
{
    Rigidbody2D playerRigidbody;
    SpriteRenderer spritecompo;
    //[SerializeField] GameObject gunPrefab;
    Vector3 mouse;
    Animator playerAnim;
    Collider2D coll;
    Inven inven;


    [Header("Slide Property")]
    Vector2 slideDirection;
    [SerializeField] float slideSpeed = 5f;
    float slideDuration = 0.5f;
    float slideCooldown = 0.5f;
    float slideTimer = 0f;
    bool isSlide = false;

    [Header("Inven Property")]
    [SerializeField] float holdTime = 1.0f;
    float pressTime = 0.0f;
    bool isPress = false;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        spritecompo = GetComponent<SpriteRenderer>();
        coll = GetComponent<CapsuleCollider2D>();
        inven = GetComponent<Inven>();
    }

    private void Update()
    {
        if (currentHP <= 0) Die();

        FollowMouse();
        PlayerMove();
        /*temp*/
        ItemThrow();
        ItemSwap();

        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }

    public void PlayerMove()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (inputX < 0) spritecompo.flipX = true;
        else spritecompo.flipX = false;

        Vector2 playerVelocity = new Vector2(inputX, inputY);
        //playerVelocity.Normalize();

        // Player Move
        playerRigidbody.velocity = playerVelocity * speed;

        if (Input.GetKeyDown(KeyCode.Space) && !isSlide)
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
    }

    IEnumerator Slide()
    {
        isSlide = true;
        playerAnim.SetBool("isRolling", true);
        slideTimer = 0f;
        coll.enabled = false;

        while (slideTimer < slideDuration)
        {
            playerRigidbody.velocity = slideDirection * slideSpeed;

            slideTimer += Time.deltaTime;
            yield return null;
        }

        playerRigidbody.velocity = Vector2.zero;
        isSlide = false;
        playerAnim.SetBool("isRolling", false);
        coll.enabled = true;

        yield return new WaitForSeconds(slideCooldown);
    }

    void Die()
    {
        playerAnim.SetTrigger("Die");

        // Scene Gameover
    }

    void ItemThrow()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            inven.ThrowWeapon();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            inven.ThrowActive();
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


    //temp
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Weapon"))
            {
                Debug.Log("Weapon Collision");
                GameObject newWeapon = other.gameObject;
                inven.GetWeapon(newWeapon);
                newWeapon.SetActive(false);
                newWeapon.transform.SetParent(transform);
            }
            if (other.CompareTag("Active"))
            {
                Debug.Log("Active Collision");
                GameObject newActive = other.gameObject;
                inven.GetActive(newActive);
                newActive.SetActive(false);
                newActive.transform.SetParent(transform);
            }
            if (other.CompareTag("Passive"))
            {
                Debug.Log("Passive Collision");
                GameObject newPassive = other.gameObject;
                inven.GetPassive(newPassive);
                newPassive.SetActive(false);
                newPassive.transform.SetParent(transform);
            }
        }
    }
}
