using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKin : Enemy
{
    // 정의할 상태 열거형(Enum)
    public enum EnemyState
    {
        Idle,
        Chasing,
        Attacking,
        Dead
    }

    private EnemyState currentState = EnemyState.Idle;

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                UpdateIdleState();
                break;

            case EnemyState.Chasing:
                UpdateChasingState();
                break;

            case EnemyState.Attacking:
                UpdateAttackingState();
                break;

            case EnemyState.Dead:
                //죽었을 때
                break;
        }
    }

    private void UpdateIdleState()
    {
        // Idle 상태 변환
    }

    private void UpdateChasingState()
    {
        // 추격 상태 변환 
    }

    private void UpdateAttackingState()
    {
        // 공격 패턴 상태변환
    }

    public void ChangeState(EnemyState newState)
    {
        currentState = newState;
    }

    public void StartChasing()
    {
        ChangeState(EnemyState.Chasing);
    }

    public void StartAttacking()
    {
        ChangeState(EnemyState.Attacking);
    }

    public void Die()
    {
        ChangeState(EnemyState.Dead);
    }
}
