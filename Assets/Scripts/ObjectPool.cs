using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private readonly List<PoolObjectTemplate<T>> _templates;
    private readonly List<T> _pool = new List<T>();

    public ObjectPool(List<PoolObjectTemplate<T>> templates)
    {
        _templates = templates;
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
        foreach (var poolObject in _templates)
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
        var template = _templates[Random.Range(0, _templates.Count)].Template;
        return InstantiatePoolObject(template);
    }
}

[System.Serializable]
public class PoolObjectTemplate<T> where T : Component
{
    [SerializeField] private T _template;
    [SerializeField] private int _count;

    public T Template => _template;
    public int Count => _count;
}
