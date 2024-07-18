using _Game.Scripts.Asteroids;
using _Game.Scripts.Character;
using _Game.Scripts.Pool;
using _Game.Scripts.Scores;
using _Game.Scripts.Shooting;
using _Game.Scripts.UFO;
using _Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure
{
    public class CompositeRoot : MonoBehaviour
    {
        [SerializeField] private LoseScreenUI _loseScreen;

        private PlayerController _playerController;
        private Health _health;
        private Player _player;
        private AsteroidSpawner _asteroidSpawner;
        private UfoSpawner _ufoSpawner;

        [Inject] private Pool<Asteroid> _asteroidPool;
        [Inject] private Pool<Bullet> _bulletPool;
        [Inject] private Pool<Ufo> _ufoPool;

        [Inject]
        private void Construct(Health health, Player player, Score score, PlayerController playerController,
            AsteroidSpawner asteroidSpawner, UfoSpawner ufoSpawner)
        {
            _health = health;
            _player = player;
            _playerController = playerController;
            _asteroidSpawner = asteroidSpawner;
            _ufoSpawner = ufoSpawner;
        }

        private void Start()
        {
            _playerController.EnableLaser();
            _playerController.EnableMoving();
            _playerController.EnableShooting();

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

        private void OnDied()
        {
            StopAllCoroutines();
            Destroy(_player.gameObject);
            _asteroidPool.ResetPool();
            _bulletPool.ResetPool();
            _ufoPool.ResetPool();
            _playerController.DisableLaser();
            _playerController.DisableMoving();
            _playerController.DisableShooting();
            _loseScreen.gameObject.SetActive(true);
        }
    }
}