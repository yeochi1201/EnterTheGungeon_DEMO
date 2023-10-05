using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    BASIC, //M16, OldGoldie, GUNGINE
    SPLIT, //BigShotgun(small)
    CAPSULE, //HighKaliber
    GRENADE, //M16Grenade
    SQUARE_ROUND, //DECK4RD
    SQUARE_ROUND_BS, //BigShotgun
    SQUARE_ROUND_GT, //GUNTHER
    SNIPER, //A.W.P.    
    MAKESHIFT_CANNON, //6 Projectiles
    STRAFE_GUN,    
    MAX_SIZE
}

public class ProjectilePooler : MonoBehaviour 
{
    public static ProjectilePooler Instance;

    [SerializeField] GameObject basicProjectilePrefab;
    [SerializeField] int basicProjectilePoolCount;

    [SerializeField] GameObject splitProjectilePrefab;
    [SerializeField] int splitProjectilePoolCount;

    [SerializeField] GameObject capsuleProjectilePrefab;
    [SerializeField] int capsuleProjectilePoolCount;

    [SerializeField] GameObject grenadeProjectilePrefab;
    [SerializeField] int grenadeProjectilePoolCount;

    [SerializeField] GameObject squareRoundProjectilePrefab;
    [SerializeField] int squareRoundProjectilePoolCount;

    [SerializeField] GameObject squareRoundBsProjectilePrefab;
    [SerializeField] int squareRoundBsProjectilePoolCount;

    [SerializeField] GameObject squareRoundGtProjectilePrefab;
    [SerializeField] int squareRoundGtProjectilePoolCount;

    [SerializeField] GameObject sniperProjectilePrefab;
    [SerializeField] int sniperProjectilePoolCount;

    [SerializeField] GameObject makeshiftCannonProjectilePrefab;
    [SerializeField] int makeshiftCannonProjectilePoolCount;

    [SerializeField] GameObject strafeGunProjectilePrefab;
    [SerializeField] int strafeGunProjectilePoolCount;

    List<GameObject>[] projectilePool = new List<GameObject>[(int)ProjectileType.MAX_SIZE];


    private void Awake()
    {
        Instance = this;

        projectilePool[(int)ProjectileType.BASIC] = new List<GameObject>();
        projectilePool[(int)ProjectileType.SPLIT] = new List<GameObject>();
        projectilePool[(int)ProjectileType.CAPSULE] = new List<GameObject>();
        projectilePool[(int)ProjectileType.GRENADE] = new List<GameObject>();
        projectilePool[(int)ProjectileType.SQUARE_ROUND] = new List<GameObject>();
        projectilePool[(int)ProjectileType.SQUARE_ROUND_BS] = new List<GameObject>();
        projectilePool[(int)ProjectileType.SQUARE_ROUND_GT] = new List<GameObject>();
        projectilePool[(int)ProjectileType.SNIPER] = new List<GameObject>();
        projectilePool[(int)ProjectileType.MAKESHIFT_CANNON] = new List<GameObject>();
        projectilePool[(int)ProjectileType.STRAFE_GUN] = new List<GameObject>();

        for (int i = 0; i < basicProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(basicProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.BASIC].Add(_projectile);
        }

        for (int i = 0; i < splitProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(splitProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.SPLIT].Add(_projectile);
        }

        for (int i = 0; i < capsuleProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(capsuleProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.CAPSULE].Add(_projectile);
        }

        for (int i = 0; i < grenadeProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(grenadeProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.GRENADE].Add(_projectile);
        }

        for (int i = 0; i < squareRoundProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(squareRoundProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.SQUARE_ROUND].Add(_projectile);
        }

        for (int i = 0; i < squareRoundBsProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(squareRoundBsProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.SQUARE_ROUND_BS].Add(_projectile);
        }

        for (int i = 0; i < squareRoundGtProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(squareRoundGtProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.SQUARE_ROUND_GT].Add(_projectile);
        }

        for (int i = 0; i < sniperProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(sniperProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.SNIPER].Add(_projectile);
        }

        for (int i = 0; i < makeshiftCannonProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(makeshiftCannonProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.MAKESHIFT_CANNON].Add(_projectile);
        }

        for (int i = 0; i < strafeGunProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(strafeGunProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.STRAFE_GUN].Add(_projectile);
        }
    }

    public GameObject GetProjectile(ProjectileType _projectileType)
    {
        if (projectilePool[(int)_projectileType] == null)
        {
            Debug.Log("Set Projectile Type");
            return null;
        }

        for (int i = 0; i < projectilePool[(int)_projectileType].Count; i++)
        {
            if (!projectilePool[(int)_projectileType][i].activeInHierarchy)
            {
                return projectilePool[(int)_projectileType][i];
            }
        }

        return null;
    }

}