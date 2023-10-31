using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_Instance;       // 유일성이 보장
    static Managers Instance { get { Init(); return s_Instance; } }      // 유일한 매니저를 갖고온다

    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();
    InvenUI _invenUI = new InvenUI();

    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static InvenUI InvenUI { get { return Instance._invenUI; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    static void Init()
    {
        if (s_Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_Instance = go.GetComponent<Managers>();
        }
    }
}
