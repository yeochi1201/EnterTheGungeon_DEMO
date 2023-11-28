using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    int spawnCount;
    [SerializeField]
    GameObject[] door;
    private bool isCleared=false;

    private CompositeCollider2D spawnRange;

    public void SpawmEnemies()
    {
        if (!isCleared)
        {
            spawnRange = GameObject.Find("Floor").GetComponent<CompositeCollider2D>();
            float range_X = spawnRange.bounds.size.x;
            float range_Y = spawnRange.bounds.size.y;
            Vector2 originPosition = GameObject.Find("Floor").transform.position;

            for (int i = 0; i < spawnCount; i++)
            {
                float randRange_X = Random.Range(1, range_X - 1);
                float randRange_Y = Random.Range(1, range_Y - 1);
                Vector2 randomPosition = new Vector2(randRange_X, randRange_Y);

                Instantiate(enemy, originPosition + randomPosition, Quaternion.identity);
            }
        }
    }
    public void checkEnemyCount()   //적 제거 시 마다 호출
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
