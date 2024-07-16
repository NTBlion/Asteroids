using _Game.Scripts.Asteroids;
using _Game.Scripts.Character;
using _Game.Scripts.Pool;
using _Game.Scripts.Scores;
using _Game.Scripts.Shooting;
using _Game.Scripts.UFO;
using _Game.Scripts.UI;
using UnityEngine;

namespace _Game.Scripts
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private LoseScreenUI _loseScreen;
        [SerializeField] private Player _player;
        [SerializeField] private Laser _laser;
        [SerializeField] private Movement _movement;
        [SerializeField] private Score _score;
        [SerializeField] private AsteroidSpawner _asteroidSpawner;
        [SerializeField] private BulletSpawner _bulletSpawner;
        [SerializeField] private UfoSpawner _ufoSpawner;

        private Pool<Asteroid> _asteroidPool;
        private Pool<Bullet> _bulletPool;
        private Pool<Ufo> _ufoPool;

        private bool _thrusting = true;
        private bool _rotating = true;
        private bool _shooting = true;

        private void Awake()
        {
            _asteroidPool = new Pool<Asteroid>(_asteroidSpawner.Asteroid, _asteroidSpawner.PoolCapacity,
                _asteroidSpawner.Container);
            _bulletPool = new Pool<Bullet>(_bulletSpawner.Bullet, _bulletSpawner.PoolCapacity, _bulletSpawner.Container);
            _ufoPool = new Pool<Ufo>(_ufoSpawner.Ufo, _ufoSpawner.PoolCapacity, _ufoSpawner.Container);
        
            _asteroidSpawner.Init(_asteroidPool, _score);
            _bulletSpawner.Init(_bulletPool);
            _ufoSpawner.Init(_player, _ufoPool);
            _player.Init(_health);
        
            StartCoroutine(_asteroidSpawner.StartSpawn());
            StartCoroutine(_ufoSpawner.StartSpawn());
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
                _bulletSpawner.Spawn();

            if (_rotating)
                _movement.Rotate();
        
            if(Input.GetMouseButtonDown(1) && _laser.IsActive == false)
                StartCoroutine(_laser.ActivateLaser());
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
            _bulletPool.ResetPool();
            _ufoPool.ResetPool();
            _thrusting = false;
            _rotating = false;
            _shooting = false;
            _loseScreen.gameObject.SetActive(true);
        }
    }
}