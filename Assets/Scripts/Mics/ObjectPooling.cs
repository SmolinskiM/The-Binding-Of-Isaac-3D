using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;

public class ObjectPooling<T> : MonoBehaviour where T : MonoBehaviour
{ 
    private IObjectPool<T> pool;
    private T objectPrefab;
    private Transform mainObject;

    public IObjectPool<T> Pool { get { return pool; } }


    public ObjectPooling(T objectPrefab, Transform mainObject, Action<T> OnTakeFromPool = null, Action<T> OnReleaseToPool = null)
    {
        if(OnTakeFromPool == null)
        {
            OnTakeFromPool = OnTake;
        }

        if(OnReleaseToPool == null)
        {
            OnReleaseToPool = OnRelease;
        }

        this.mainObject = mainObject;
        this.objectPrefab = objectPrefab;
        pool = new ObjectPool<T>(CreateObject, OnTakeFromPool, OnReleaseToPool);
    }

    private void OnTake(T _object)
    {
        _object.gameObject.SetActive(true);
    }

    private void OnRelease(T _object)
    {
        _object.gameObject.SetActive(false);
    }

    private T CreateObject()
    {
        T _object = Instantiate(objectPrefab, mainObject.position, Quaternion.identity, mainObject);
        return _object;
    }
}
