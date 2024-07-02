using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_2021_3_OR_NEWER
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    public int ObjectCapacity;

    public GameObject ObjectPrefab;

    public IObjectPool<GameObject> ObjectPool { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Init()
    {
        ObjectPool = new UnityEngine.Pool.ObjectPool<GameObject>(CreateItem, OnTakeFromPool, OnReturnedToPool,
        OnDestroyPoolObject, true, ObjectCapacity, ObjectCapacity);
        for (int i = 0; i < ObjectCapacity; i++)
        {
            GameObject Paper = CreateItem();
            ObjectPool.Release(Paper.gameObject);
        }
    }
    private GameObject CreateItem()
    {
        GameObject poolGo = Instantiate(ObjectPrefab);
        return poolGo;
    }
    private void OnTakeFromPool(GameObject poolGo)
    {

    }
    private void OnReturnedToPool(GameObject poolGo)
    {
    }
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        //Destroy(poolGo);
    }
}
#endif