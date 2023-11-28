using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    int spawnCount;
    [SerializeField]
    GameObject spawnPoint;
    [SerializeField]
    GameObject[] door;
    private bool isCleared=false;

    private TilemapCollider2D spawnRange;

    public void SpawmEnemies()
    {
        if (!isCleared)
        {
            spawnRange = GameObject.Find("Floor").GetComponent<TilemapCollider2D>();
            float range_X = spawnRange.bounds.size.x;
            float range_Y = spawnRange.bounds.size.y;
            Vector2 originPosition = spawnPoint.transform.position;

            for (int i = 0; i < spawnCount; i++)
            {
                float randRange_X = Random.Range(0, range_X);
                float randRange_Y = Random.Range(0, range_Y);
                Vector2 randomPosition = new Vector2(randRange_X, randRange_Y);

                Instantiate(enemy, originPosition + randomPosition, Quaternion.identity);
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
