using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletOwner //Bullet 발사 주체
{
    PLAYER,
    ENEMY,    
    MAX_SIZE,
}

public class BulletPooler : MonoBehaviour
{
    public static BulletPooler Instance;

    [SerializeField] GameObject playerBulletPrefab;
    [SerializeField] int playerBulletPoolCount;

    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] int enemyBulletPoolCount;

    List<GameObject>[] bulletPool = new List<GameObject>[(int)BulletOwner.MAX_SIZE];


    private void Awake()
    {
        Instance = this;

        bulletPool[(int)BulletOwner.PLAYER] = new List<GameObject>();
        bulletPool[(int)BulletOwner.ENEMY] = new List<GameObject>();

        for (int i = 0; i < playerBulletPoolCount; i++)
        {
            GameObject _bullet = Instantiate(playerBulletPrefab);
            _bullet.SetActive(false);
            _bullet.transform.SetParent(transform);

            bulletPool[(int)BulletOwner.PLAYER].Add(_bullet);
        }

        for (int i = 0; i < enemyBulletPoolCount; i++)
        {
            GameObject _bullet = Instantiate(enemyBulletPrefab);
            _bullet.SetActive(false);
            _bullet.transform.SetParent(transform);

            bulletPool[(int)BulletOwner.ENEMY].Add(_bullet);
        }        
    }

    public GameObject GetBullet(BulletOwner _bulletOwner)//Bullet 가져오기
    {
        if (bulletPool[(int)_bulletOwner] == null)
        {
            Debug.Log("Set Bullet Owner");
            return null;
        }

        for (int i = 0; i < bulletPool[(int)_bulletOwner].Count; i++)
        {
            if (!bulletPool[(int)_bulletOwner][i].activeInHierarchy)
            {
                return bulletPool[(int)_bulletOwner][i];
            }         
        }
        
        return null;
    }

}
