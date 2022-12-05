using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling<T> : MonoBehaviour where T : MonoBehaviour
{
    private IObjectPool<T> pool;
    private T objectPrefab;
    private Transform mainObject;

    public IObjectPool<T> Pool { get { return pool; } }


    public ObjectPooling(T objectPrefab, Transform mainObject)
    {
        this.mainObject = mainObject;
        this.objectPrefab = objectPrefab;
        pool = new ObjectPool<T>(CreateObject, OnTakeFromPool, OnReleaseToPool);
    }

    private void OnTakeFromPool(T _object)
    {
        _object.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(T _object)
    {
        _object.gameObject.SetActive(false);
    }

    private T CreateObject()
    {
        T _object = Instantiate(objectPrefab, mainObject.position, Quaternion.identity);
        return _object;
    }
}
