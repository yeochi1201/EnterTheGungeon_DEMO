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
    [SerializeField]
    GameObject telepoter;

    private bool isCleared = false;
    private bool isActived = false;
    private GameObject spawnPoint;
    private float range_X, range_Y;
    private BoxCollider2D spawnRange;
    private Vector2 originPosition;

    public void SpawmEnemies()
    {

        if (!isCleared && !isActived)
        {
             if (enemies.Length == 0)
            {
                if (telepoter != null)
                {
                    telepoter.GetComponentInChildren<Animator>().SetBool("IsActivated", true);
                }
                isCleared = true;
            }
            else
            {
                foreach (GameObject obj in door)
                {
                    obj.SetActive(true);
                }
                for (int i = 0; i < spawnCount; i++)
                {
                    spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                    spawnRange = spawnPoint.GetComponent<BoxCollider2D>();
                    range_X = spawnRange.bounds.size.x;
                    range_Y = spawnRange.bounds.size.y;
                    originPosition = spawnPoint.transform.position;
                    float randRange_X = Random.Range(0, range_X);
                    float randRange_Y = Random.Range(0, range_Y);
                    Vector2 randomPosition = new Vector2(randRange_X, randRange_Y);

                    Instantiate(enemies[Random.Range(0, enemies.Length)], originPosition + randomPosition, Quaternion.identity).transform.parent = this.transform;
                }
            }
            isActived=true;
        }
    }
    public void CheckEnemyCount()
    {
        this.spawnCount--;
        if (spawnCount <= 0)
        {
            foreach (GameObject obj in door)
            {
                obj.SetActive(false);
            }
            if (telepoter != null)
            {
                telepoter.GetComponentInChildren<Animator>().SetBool("IsActivated",true);
            }
            isCleared = true;
        }
    }
    public void PlusEnemyCount(int i)
    {
        spawnCount += i;
    }

}
