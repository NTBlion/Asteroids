using System;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private LoseScreenUI _loseScreen;
    [SerializeField] private Player _player;
    [SerializeField] private BulletSpawner _bullet;
    [SerializeField] private Movement _movement;
    [SerializeField] private AsteroidSpawner _asteroidSpawner;
    [SerializeField] private BulletSpawner _bulletSpawner;

    private Pool<Asteroid> _asteroidPool;
    private Pool<SmallAsteroid> _smallAsteroidPool;
    private Pool<Bullet> _bulletPool;

    private bool _thrusting = true;
    private bool _rotating = true;
    private bool _shooting = true;

    private void Awake()
    {
        _asteroidPool = new Pool<Asteroid>(_asteroidSpawner.Asteroid, _asteroidSpawner.PoolCapacity,
            _asteroidSpawner.Container);
        _smallAsteroidPool = new Pool<SmallAsteroid>(_asteroidSpawner.SmallAsteroid, _asteroidSpawner.PoolCapacity,
            _asteroidSpawner.Container);
        _bulletPool = new Pool<Bullet>(_bulletSpawner.Bullet, _bulletSpawner.PoolCapacity, _bulletSpawner.Container);
        
        _asteroidSpawner.Init(_asteroidPool, _smallAsteroidPool);
        _bulletSpawner.Init(_bulletPool);
        _player.Init(_health);
        
        StartCoroutine(_asteroidSpawner.StartSpawn());
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _shooting)
            _bullet.Spawn();

        if (_rotating)
            _movement.Rotate();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && _thrusting)
            _movement.Move();
    }

    private void OnDied()
    {
        StopAllCoroutines();
        Destroy(_player.gameObject);
        _asteroidPool.ResetPool();
        _smallAsteroidPool.ResetPool();
        _bulletPool.ResetPool();
        _thrusting = false;
        _rotating = false;
        _shooting = false;
        _loseScreen.gameObject.SetActive(true);
    }
}