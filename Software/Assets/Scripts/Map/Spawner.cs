using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    int spawnCount;
    [SerializeField]
    GameObject[] spawnPoints;
    [SerializeField]
    GameObject[] door;

    private bool isCleared=false;
    private GameObject spawnPoint;
    private float range_X, range_Y;
    private BoxCollider2D spawnRange;
    private Vector2 originPosition;

    public void SpawmEnemies()
    {
        if (!isCleared)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];   //배열안의 스폰 범위 중 하나 랜덤 선택
                spawnRange = spawnPoint.GetComponent<BoxCollider2D>();
                range_X = spawnRange.bounds.size.x;
                range_Y = spawnRange.bounds.size.y;
                originPosition = spawnPoint.transform.position;
                float randRange_X = Random.Range(0, range_X);
                float randRange_Y = Random.Range(0, range_Y);
                Vector2 randomPosition = new Vector2(randRange_X, randRange_Y);


                Instantiate(enemies[Random.Range(0, enemies.Length)], originPosition + randomPosition, Quaternion.identity);
            }
        }
    }
    public void CheckEnemyCount()   //적 제거 시 마다 호출
    {
        this.spawnCount--;
        if (spawnCount <= 0)    //최초 설정한 몹 수 제거 시
        {
            isCleared = true;
            foreach (GameObject obj in door)    //문 open
            {
                obj.GetComponent<Door>().Open();
            }
        }
            
    }
}
