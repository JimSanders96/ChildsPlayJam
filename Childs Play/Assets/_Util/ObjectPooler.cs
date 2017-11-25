using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This pool relies heavily on having the indices of the public arrays reference the same conceptual thing.
/// This behavior is enforced in the Start() method and through the values entered into this script
/// 
/// E.G. If I want to pool 20 CandyBar prefabs and don't want the pool to expand, I allocate the values 'CandyBar', 
///      '20' and 'false' to the same index in their respective arrays.
///      
/// The names of prefabs allocated to the pooledObjects array serve as the indentifier for retrieving pooled objects.
/// 
/// E.G. If I want to get an instance of the CandyBar prefab, I call GetPooledObject("CandyBar");
/// 
/// </summary>

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;

    public GameObject[] pooledObjects;
    public int[] pooledAmounts;
    public bool[] willGrow;

    List<List<GameObject>> poolContainer;
    List<string> prefabNames;

    public bool DoesExist()
    {
        return instance != null;
    }

    void Awake()
    {
        instance = this;
        InitializeObjectPools();
    }

    void InitializeObjectPools()
    {
        prefabNames = new List<string>();
        poolContainer = new List<List<GameObject>>();

        for (int i = 0; i < pooledObjects.Length; i++)
        {
            // Create a pool for an object
            GameObject obj = pooledObjects[i];
            List<GameObject> newPool = new List<GameObject>();
            for (int y = 0; y < pooledAmounts[i]; y++)
            {
                AddObjectToPool(newPool, obj, false);
            }
            poolContainer.Add(newPool);

            // Create an identifier for lookup (the prefab name of the object)
            prefabNames.Add(pooledObjects[i].name);
        }
    }

    List<GameObject> GetObjectPool(string prefabName)
    {
        if (!prefabNames.Contains(prefabName))
        {
            Debug.LogWarning("Pool does not exist for given prefabName - GetPool()");
            return null;
        }

        return poolContainer[prefabNames.IndexOf(prefabName)];
    }

    public GameObject GetPooledObject(string prefabName)
    {
        List<GameObject> pool = GetObjectPool(prefabName);
        if (pool == null)
        {
            Debug.LogWarning("Pool does not exist for given prefabName - GetPooledObject()");
            return null;
        }

        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        int poolIndex = poolContainer.IndexOf(pool);

        if (willGrow[poolIndex])
        {
            return AddObjectToPool(pool, pooledObjects[poolIndex], false);
        }

        return null;
    }

    GameObject AddObjectToPool(List<GameObject> pool, GameObject objectToPool, bool setActive)
    {
        GameObject obj = Instantiate(objectToPool);
        obj.SetActive(setActive);
        pool.Add(obj);
        return obj;
    }

}
