using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    GameObject startPoint;
    [SerializeField]
    GameObject endPoint;
    [SerializeField]
    GameObject chestSpawner;
    [SerializeField]
    GameObject player;


    void Start()
    {
        Invoke("InstantiatePlayer", 1.5f);
        chestSpawner.GetComponent<ChestSpawner>().SpawnChest();
    }

   public void RemoveStartPoint()
    {
        startPoint.GetComponent<Animator>().SetTrigger("Exit");
        Invoke("DisableStartPoint", 1.5f);

    }
    private void DisableStartPoint()
    {
        startPoint.SetActive(false);
    }

    public void RemoveEndPoint()
    {
        endPoint.GetComponent<Animator>().SetTrigger("Exit");
        //Invoke("DisablePlayer", 0.3f);
        Invoke("SceneChange", 1.5f);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("BaseCamp");
    }
    void InstantiatePlayer()
    {
        Instantiate(player, startPoint.transform.position, Quaternion.identity);
    }
    void DisablePlayer()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
    }





}
