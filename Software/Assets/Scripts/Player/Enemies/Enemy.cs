using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Enemy Property")]
    [SerializeField] public float speed = 1.0f;
    [SerializeField] public float health = 3.0f;
    public float damage = 1.0f;
    [SerializeField] public float distance; //distance between player and monster
    [SerializeField] public float moveRange = 7.0f;
    [SerializeField] public float attackRange = 2.0f;
    [SerializeField] public float attackCooldown = 3.0f;
}
