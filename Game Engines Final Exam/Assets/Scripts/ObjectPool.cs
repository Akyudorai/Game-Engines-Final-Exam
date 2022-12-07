using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    public List<GameObject> pool;    

    public static ObjectPool Initialize(GameObject prefab, int count)
    {   
        ObjectPool op = new ObjectPool();
        op.pool = new List<GameObject>();
        for (int i = 0; i < count; i++) 
        {
            GameObject newObj = GameObject.Instantiate(prefab);
            newObj.SetActive(false);
            op.pool.Add(newObj);
        }
        return op;
    }

    public GameObject GetObjectFromPool() 
    {
        for (int i = 0; i < pool.Count; i++) 
        {
            if (!pool[i].activeInHierarchy) return pool[i];            
        }

        return null;
    }
}
