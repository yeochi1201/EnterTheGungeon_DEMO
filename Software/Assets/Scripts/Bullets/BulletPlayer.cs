using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletPlayer : MonoBehaviour
{
    [Header("Player Move Property")]
    [SerializeField] float playerSpeed = 5;
    Rigidbody2D playerRigdbody;   

    [Header("Gun Property")]
    [SerializeField] GameObject muzzle;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject gunPivot;
    [SerializeField] Vector2 muzzleDirection;
    Vector2 target;
    Vector2 mouse;
    float angle;


    private void Awake()
    {
        playerRigdbody = GetComponent<Rigidbody2D>();
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

        Vector2 playerVelocty = new Vector2(inputX, inputY);

        playerRigdbody.velocity = playerVelocty * playerSpeed;
    }

    public void FollowMouse()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        gunPivot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Shooting()
    {
        muzzleDirection = muzzle.transform.right;

        GameObject _bullet = BulletPooler.Instance.GetBullet(BulletOwner.PLAYER);        
        _bullet.transform.position = muzzle.transform.position;        
        _bullet.GetComponent<Bullet>().SetDirection(muzzleDirection);
        _bullet.SetActive(true);
    }
}
