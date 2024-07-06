using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _container;
    
    private List<GameObject> _objects;
    
    private void Awake()
    {
        _objects = new List<GameObject>();

        for (int i = 0; i < _capacity; i++)
        {
            var obj = Instantiate(_prefab, _container);
            obj.SetActive(false);
            _objects.Add(obj);
        }
    }

    protected GameObject EnableObject()
    {
        var obj = _objects.FirstOrDefault(p => p.activeSelf == false);

        if (obj == null)
        {
            obj = Create();
            _objects.Add(obj);
        }
        
        obj.gameObject.SetActive(true);
        return obj;
    }

    protected void Disable(GameObject obj)
    {
        obj.SetActive(false);
    }

    protected void ResetPool()
    {
        foreach (var obj in _objects)
        {
            obj.SetActive(false);
        }
    }

    private GameObject Create()
    {
        Instantiate(_prefab);
        _objects.Add(_prefab);
        return _prefab;
    }
}