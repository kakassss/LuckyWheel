using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPool<T> where T : Component
{
    private readonly T _prefab;
    private readonly int _poolSize;
    private readonly Transform _poolParent;

    private readonly IInstantiator _instantiator;
    
    private List<T> _objectPoolList = new List<T>();
    private Vector3 _spawnPosition;
    
    public ObjectPool(T prefab, int poolSize, Transform poolParent, IInstantiator instantiator)
    {
        _prefab = prefab;
        _poolSize = poolSize;
        _poolParent = poolParent;
        _instantiator = instantiator;
        
        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            T obj = _instantiator.InstantiatePrefabForComponent<T>(_prefab, _poolParent);
            obj.gameObject.SetActive(false);
            _objectPoolList.Add(obj);
        }
        _spawnPosition = _poolParent.transform.position;
    }
    
    public T GetFromPool()
    {
        if (_objectPoolList.Count == 0)
        {
            T obj = _instantiator.InstantiatePrefabForComponent<T>(_prefab, _poolParent);
            return obj;
        }
        
        T gameObject = _objectPoolList[0];
        _objectPoolList.RemoveAt(0);
        gameObject.gameObject.SetActive(true);
        return gameObject;
    }

    public void ReturnToPool(T obj)
    {
        _objectPoolList.Add(obj);
        obj.gameObject.SetActive(false);
        obj.transform.position = _spawnPosition;
    }
}