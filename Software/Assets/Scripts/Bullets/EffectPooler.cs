using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EffectType
{
    BULLET_IMPACT,
    EXPLOSION_IMPACT,
    SPLIT_IMPACT,
    MAX_SIZE,
}

public class EffectPooler : MonoBehaviour
{
    public static EffectPooler Instance;

    [SerializeField] GameObject bulletImpactPrefab;
    [SerializeField] int bulletImpactPoolCount;
    [SerializeField] GameObject explosionImpactPrefab;
    [SerializeField] int explosionImpactPoolCount;
    [SerializeField] GameObject splitImpactPrefab;
    [SerializeField] int splitImpactPoolCount;

    List<GameObject>[] effectPool = new List<GameObject>[(int)EffectType.MAX_SIZE];


    private void Awake()
    {
        Instance = this;

        effectPool[(int)EffectType.BULLET_IMPACT] = new List<GameObject>();
        effectPool[(int)EffectType.EXPLOSION_IMPACT] = new List<GameObject>();
        effectPool[(int)EffectType.SPLIT_IMPACT] = new List<GameObject>();

        for (int i = 0; i < bulletImpactPoolCount; i++)
        {
            GameObject _bullet = Instantiate(bulletImpactPrefab);
            _bullet.SetActive(false);
            _bullet.transform.SetParent(transform);

            effectPool[(int)EffectType.BULLET_IMPACT].Add(_bullet);
        }

        for (int i = 0; i < explosionImpactPoolCount; i++)
        {
            GameObject _bullet = Instantiate(explosionImpactPrefab);
            _bullet.SetActive(false);
            _bullet.transform.SetParent(transform);

            effectPool[(int)EffectType.EXPLOSION_IMPACT].Add(_bullet);
        }

        for (int i = 0; i < splitImpactPoolCount; i++)
        {
            GameObject _bullet = Instantiate(splitImpactPrefab);
            _bullet.SetActive(false);
            _bullet.transform.SetParent(transform);

            effectPool[(int)EffectType.SPLIT_IMPACT].Add(_bullet);
        }
    }

    public GameObject GetEffect(EffectType _effectType) //Get Bullet
    {
        if (effectPool[(int)_effectType] == null)
        {
            return null;
        }

        for (int i = 0; i < effectPool[(int)_effectType].Count; i++)
        {
            if (!effectPool[(int)_effectType][i].activeInHierarchy)
            {
                return effectPool[(int)_effectType][i];
            }
        }

        return null;
    }
}
