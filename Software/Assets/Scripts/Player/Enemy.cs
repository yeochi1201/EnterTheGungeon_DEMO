using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Enemy Property")]
    float speed = 1.0f;
    float health = 3.0f;
    float damage = 1.0f;
    float moveRange = 7.0f;
    float distance; // distance between player and enemy
    float attackRange = 2.0f;
    float attackCooldown = 2.0f;

}
