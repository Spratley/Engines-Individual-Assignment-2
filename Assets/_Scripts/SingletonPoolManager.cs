using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPoolManager
{
    private SingletonPoolManager()
    {
        Objects = new Queue<GameObject>();
        init = false;
    }

    public static SingletonPoolManager GetInstance()
    {
        if (poolManager == null)
        {
            poolManager = new SingletonPoolManager();
        }
        return poolManager;
    }

    private static SingletonPoolManager poolManager;
    private static bool init;

    public GameObject GetObject()
    {
        GameObject obj = Objects.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void PoolObject(GameObject obj)
    {
        obj.SetActive(false);
        Objects.Enqueue(obj);
    }

    public void InitFilled(GameObject prefab, int count)
    {

        if (!init)
        {
            for (int i = 0; i < count; ++i)
            {
                Objects.Enqueue(Create(prefab));
            }
        }
        init = true;
    }

    public GameObject Create(GameObject prefab)
    {
        GameObject obj = MonoBehaviour.Instantiate(prefab);
        obj.SetActive(false);
        return obj;
    }

    public Queue<GameObject> Objects;
}