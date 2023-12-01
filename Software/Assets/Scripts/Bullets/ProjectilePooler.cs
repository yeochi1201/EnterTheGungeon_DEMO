using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    VELOCITY,
    HELIX,
    HOMING,
    COLOR,
    TRAIL,
    RAY,
    SPLIT,
    ENEMY_BASIC,
    ENEMY_ANOMALY,
    MAX_SIZE
}

public class ProjectilePooler : MonoBehaviour 
{
    public static ProjectilePooler Instance;
    public ProjectileType type;

    [SerializeField] GameObject velocityProjectilePrefab;
    [SerializeField] int velocityProjectilePoolCount;

    [SerializeField] GameObject helixProjectilePrefab;
    [SerializeField] int helixProjectilePoolCount;

    [SerializeField] GameObject homingProjectilePrefab;
    [SerializeField] int homingProjectilePoolCount;

    [SerializeField] GameObject colorProjectilePrefab;
    [SerializeField] int colorProjectilePoolCount;

    [SerializeField] GameObject trailProjectilePrefab;
    [SerializeField] int trailProjectilePoolCount;

    [SerializeField] GameObject rayProjectilePrefab;
    [SerializeField] int rayProjectilePoolCount;

    [SerializeField] GameObject splitProjectilePrefab;
    [SerializeField] int splitProjectilePoolCount;

    [SerializeField] GameObject enemyBasicProjectilePrefab;
    [SerializeField] int enemyBasicProjectilePoolCount;

    [SerializeField] GameObject enemyAnomalyProjectilePrefab;
    [SerializeField] int enemyAnomalyProjectilePoolCount;

    List<GameObject>[] projectilePool = new List<GameObject>[(int)ProjectileType.MAX_SIZE];


    private void Awake()
    {
        Instance = this;

        projectilePool[(int)ProjectileType.VELOCITY] = new List<GameObject>();
        projectilePool[(int)ProjectileType.HELIX] = new List<GameObject>();
        projectilePool[(int)ProjectileType.HOMING] = new List<GameObject>();
        projectilePool[(int)ProjectileType.COLOR] = new List<GameObject>();
        projectilePool[(int)ProjectileType.TRAIL] = new List<GameObject>();
        projectilePool[(int)ProjectileType.RAY] = new List<GameObject>();
        projectilePool[(int)ProjectileType.SPLIT] = new List<GameObject>();
        projectilePool[(int)ProjectileType.ENEMY_BASIC] = new List<GameObject>();
        projectilePool[(int)ProjectileType.ENEMY_ANOMALY] = new List<GameObject>();

        for (int i = 0; i < velocityProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(velocityProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.VELOCITY].Add(_projectile);
        }

        for (int i = 0; i < helixProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(helixProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.HELIX].Add(_projectile);
        }

        for (int i = 0; i < homingProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(homingProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.HOMING].Add(_projectile);
        }

        for (int i = 0; i < colorProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(colorProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.COLOR].Add(_projectile);
        }

        for (int i = 0; i < trailProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(trailProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.TRAIL].Add(_projectile);
        }

        for (int i = 0; i < rayProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(rayProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.RAY].Add(_projectile);
        }

        for (int i = 0; i < splitProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(splitProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.SPLIT].Add(_projectile);
        }

        for (int i = 0; i < enemyBasicProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(enemyBasicProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.ENEMY_BASIC].Add(_projectile);
        }

        for (int i = 0; i < enemyAnomalyProjectilePoolCount; i++)
        {
            GameObject _projectile = Instantiate(enemyAnomalyProjectilePrefab);
            _projectile.SetActive(false);
            _projectile.transform.SetParent(transform);

            projectilePool[(int)ProjectileType.ENEMY_ANOMALY].Add(_projectile);
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