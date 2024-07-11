using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private T _prefab;
    private int _capacity;
    private Transform _container;
    private readonly List<T> _objects;

    public Pool(T prefab, int capacity, Transform container)
    {
        _prefab = prefab;
        _capacity = capacity;
        _objects = new List<T>();

        for (int i = 0; i < capacity; i++)
        {
            var obj = GameObject.Instantiate(prefab, container);
            obj.gameObject.SetActive(false);
            Objects.Add(obj);
        }
    }

    public List<T> Objects => _objects;

    public T EnableObject()
    {
        var obj = Objects.FirstOrDefault(p => p.isActiveAndEnabled == false);

        if (obj == null)
        {
            obj = Create();
            obj.gameObject.SetActive(true);
            return obj;
        }

        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Disable(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    public void ResetPool()
    {
        foreach (var obj in Objects)
        {
            obj.gameObject.SetActive(false);
        }
    }

    private T Create()
    {
        var obj = GameObject.Instantiate(_prefab, _container);
        Objects.Add(obj);
        return obj;
    }
}