using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Asteroid _asteroid;
    [SerializeField] private SmallAsteroid _smallAsteroid;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private Transform _container;

    private Pool<Asteroid> _asteroidPool;
    private Pool<SmallAsteroid> _smallAsteroidPool;

    private void Awake()
    {
        _asteroidPool = new Pool<Asteroid>(_asteroid, _poolCapacity, _container);
        _smallAsteroidPool = new Pool<SmallAsteroid>(_smallAsteroid, _poolCapacity, _container);
        
    }
    
    private void Start()
    {
        Spawn(10);
    }

    public void Spawn(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var asteroid = _asteroidPool.EnableObject();
            asteroid.Init(_asteroidPool);
            asteroid.Splitted.AddListener(Split);

            asteroid.transform.position = _spawnPoint[Random.Range(0, _spawnPoint.Length)].position;
        }
    }

    private void Split(Asteroid asteroid)
    {
        for (int i = 0; i < 2; i++)
        {
            var smallAsteroid = _smallAsteroidPool.EnableObject();
            smallAsteroid.Init(_smallAsteroidPool);

            smallAsteroid.transform.position = asteroid.transform.position;
        }
        
    }
}