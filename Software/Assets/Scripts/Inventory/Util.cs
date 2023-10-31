using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
        {
            component = go.AddComponent<T>();
        }

        return component;
    }
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
        {
            return null;
        }

        return transform.gameObject;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
        {
            return null;
        }

        if (recursive == false)         // 직속 자신만
        {
            for(int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component == null)
                        return component;
                }
            }
        }

        else
        {
            T component = FindInChildren<T>(go.transform, name);
            if (component != null)
            {
                return component;
            }

            /*foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }*/
        }

        return null;
    }


    // 비활성화된 오브젝트도 찾기
    private static T FindInChildren<T>(Transform parent, string name) where T : UnityEngine.Object
    {
        T component = null;
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform childTransform = parent.GetChild(i);
            if (string.IsNullOrEmpty(name) || childTransform.name == name)
            {
                component = childTransform.GetComponent<T>();
                if (component != null)
                {
                    return component;
                }
            }

            // 재귀적으로 하위 자식 검색
            component = FindInChildren<T>(childTransform, name);
            if (component != null)
            {
                return component;
            }
        }

        return component;
    }
}
