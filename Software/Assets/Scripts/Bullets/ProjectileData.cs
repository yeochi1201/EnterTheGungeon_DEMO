using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ProjectileElement
{
    public string projectileName;    
    public Sprite projectileSprite;    
    public string colliderType;
    public float colliderSizeX;
    public float colliderSizeY;
}

[CreateAssetMenu(fileName = "Projectile Data", menuName = "Scriptable Object/Projectile Data", order = int.MaxValue)]
public class ProjectileData : ScriptableObject
{    
    public SerializedDictionary<string, ProjectileElement> projectileElement;
}
