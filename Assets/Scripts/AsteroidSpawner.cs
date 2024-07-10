using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Asteroid _asteroid;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private Transform _container;

    private Pool<Asteroid> _pool;

    private void Awake()
    {
        _pool = new Pool<Asteroid>(_asteroid, _poolCapacity, _container);
    }

    private void Start()
    {
        Spawn(10);
    }

    public void Spawn(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var asteroid = _pool.EnableObject();
            asteroid.Init(_pool);

            asteroid.transform.position = _spawnPoint[Random.Range(0, _spawnPoint.Length)].position;
        }
    }
}