using System;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private Transform _container;

    private Pool<Bullet> _pool;

    private void Awake()
    {
        _pool = new Pool<Bullet>(_bullet, _poolCapacity, _container);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Spawn();
    }

    public void Spawn()
    {
        var bullet = _pool.EnableObject();
        bullet.Init(_pool);
        bullet.transform.position = _shootPoint.position;
        bullet.transform.rotation = _shootPoint.transform.rotation;
    }
}

