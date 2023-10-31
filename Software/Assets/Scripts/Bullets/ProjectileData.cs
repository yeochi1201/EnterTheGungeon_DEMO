using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ProjectileElement
{
    [SerializeField] public Sprite projectileSprite;
    [SerializeField] public string colliderType;
    [SerializeField] public float colliderSize;
    [SerializeField] public float ifcolliderSizey;
}

[CreateAssetMenu(fileName = "Projectile Data", menuName = "Scriptable Object/Projectile Data", order = int.MaxValue)]
public class ProjectileData : ScriptableObject
{
    [SerializeField] public ProjectileElement[] projectileData;
}
