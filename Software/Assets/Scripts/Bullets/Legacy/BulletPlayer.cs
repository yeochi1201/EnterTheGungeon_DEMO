using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

//for Bullet Test Scirpt
public class BulletPlayer : MonoBehaviour
{
    [Header("Player Move Property")]
    [SerializeField] float playerSpeed = 5;
    Rigidbody2D playerRigidbody;

    [Header("Gun Property")]
    [SerializeField] GameObject muzzle;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject gunPivot;
    [SerializeField] Vector2 muzzleDirection;
    Vector2 target;
    Vector2 mouse;
    float angle;

    [Header("Slide Property")]
    Vector2 slideDirection;
    float slideSpeed = 5f;
    float slideDuration = 0.5f;
    float slideCooldown = 0.5f;
    float slideTimer = 0f;
    bool isSlide = false;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FollowMouse();
        PlayerMove();

        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }

    public void PlayerMove()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 playerVelocity = new Vector2(inputX, inputY);

        playerRigidbody.velocity = playerVelocity * playerSpeed;

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
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        gunPivot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Shooting()
    {
        muzzleDirection = muzzle.transform.right;
        /* sniper
        GameObject _projectile = ProjectilePooler.Instance.GetProjectile(ProjectileType.SNIPER);
        _projectile.GetComponent<Projectile>().SetProjectileProperty(ProjectileType.SNIPER, 40, 100, 1000, 25, 1, 0, muzzleDirection);
        _projectile.transform.position = muzzle.transform.position;
        _projectile.gameObject.SetActive(true);
        */

        GameObject _projectile = ProjectilePooler.Instance.GetProjectile(ProjectileType.SPLIT);
        _projectile.GetComponent<SplitProjectile>().SetProjectileProperty("BigShotgun", 0, 10,40, 0, 0, 0, muzzleDirection);
        _projectile.transform.position = muzzle.transform.position;
        _projectile.gameObject.SetActive(true);
        /*
        _projectile.GetComponent<Helix>().SetProjectileProperty("Helix1", true, 0, 0, 0, 0, 0, 0, muzzleDirection);
        _projectile.transform.position = muzzle.transform.position;
        _projectile.gameObject.SetActive(true);

        GameObject _projectile1 = ProjectilePooler.Instance.GetProjectile(ProjectileType.HELIX);
        _projectile1.GetComponent<Helix>().SetProjectileProperty("Helix2", false, 0, 0, 0, 0, 0, 0, muzzleDirection);
        _projectile1.transform.position = muzzle.transform.position;
        _projectile1.gameObject.SetActive(true);
        */
    }

    IEnumerator Slide()
    {
        isSlide = true;
        slideTimer = 0f;

        while (slideTimer < slideDuration)
        {
            playerRigidbody.velocity = slideDirection * slideSpeed;

            slideTimer += Time.deltaTime;
            yield return null;
        }

        playerRigidbody.velocity = Vector2.zero;
        isSlide = false;

        yield return new WaitForSeconds(slideCooldown);
    }
}
