using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _spawnZone;
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

            var bound = _spawnZone.bounds;
            var positionX = Random.Range(bound.min.x, bound.max.x);
            var positionY = Random.Range(bound.min.y, bound.max.y);

            _spawnZone.transform.position = new Vector2(positionX, positionY);
            asteroid.transform.position = _spawnZone.transform.position;
        }
    }
}