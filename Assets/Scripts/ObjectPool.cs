using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private readonly List<PoolObject<T>> _poolObjects;
    private readonly List<T> _pool = new List<T>();

    public ObjectPool(List<PoolObject<T>> _templates)
    {
        _poolObjects = _templates;
        InitializePool();
    }

    public T GetObject()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (!_pool[i].gameObject.activeInHierarchy)
                return _pool[i];
        }

        return InstantiateRandomPoolObject();
    }
    
    public T GetRandomObject()
    {
        var inactiveObjects = _pool.FindAll(item => !item.gameObject.activeInHierarchy);

        if (inactiveObjects.Count > 0)
            return inactiveObjects[Random.Range(0, inactiveObjects.Count)];

        return InstantiateRandomPoolObject();
    }

    private void InitializePool()
    {
        foreach (var poolObject in _poolObjects)
        {
            for (int i = 0; i < poolObject.Count; i++)
            {
                InstantiatePoolObject(poolObject.Template);
            }
        }
    }

    private T InstantiatePoolObject(T template)
    {
        var poolObject = Object.Instantiate(template);
        poolObject.gameObject.SetActive(false);

        _pool.Add(poolObject);

        return poolObject;
    }

    private T InstantiateRandomPoolObject()
    {
        var template = _poolObjects[Random.Range(0, _poolObjects.Count)].Template;
        return InstantiatePoolObject(template);
    }
}

[System.Serializable]
public class PoolObject<T> where T : Component
{
    [SerializeField] private T _template;
    [SerializeField] private int _count;

    public T Template => _template;
    public int Count => _count;
}
