using System.Collections;
using _Game.Scripts.Pool;
using _Game.Scripts.Scores;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoint;
        [SerializeField] private Asteroid _asteroid;
        [SerializeField] private Vector3 _asteroidSizeAfterSplit;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private Transform _container;
        [SerializeField] private int _splitCount;
        [SerializeField] private Vector2Int _minMaxSpawnCount;

        private Pool<Asteroid> _asteroidPool;
        private Score _score;

        public Asteroid Asteroid => _asteroid;

        public int PoolCapacity => _poolCapacity;

        public Transform Container => _container;

        public void Init(Pool<Asteroid> asteroidPool, Score score)
        {
            _asteroidPool = asteroidPool;
            _score = score;
        }

        public IEnumerator StartSpawn()
        {
            while (true)
            {
                Spawn(Random.Range(_minMaxSpawnCount.x, _minMaxSpawnCount.y));
                yield return new WaitUntil(IsAsteroidsActive);
            }
        }

        private void Spawn(int spawnCount)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                var asteroid = _asteroidPool.EnableObject();
                asteroid.Init(_asteroidPool);
                asteroid.Splitted += Split;
                asteroid.Destroyed += OnDestroyed;

                asteroid.transform.position = _spawnPoint[Random.Range(0, _spawnPoint.Length)].position;
            }
        }

        private void OnDestroyed(Asteroid asteroid)
        {
            _score.AddScore();
            asteroid.Destroyed -= OnDestroyed;
        }

        private void Split(Asteroid asteroid)
        {
            for (int i = 0; i < _splitCount; i++)
            {
                var smallAsteroid = _asteroidPool.EnableObject();

                smallAsteroid.Init(_asteroidPool);
                smallAsteroid.Destroyed += OnDestroyed;
                smallAsteroid.transform.position = asteroid.transform.position;
                smallAsteroid.transform.localScale = _asteroidSizeAfterSplit;

                asteroid.Splitted -= Split;
            }
        }

        private bool IsAsteroidsActive()
        {
            foreach (var asteroid in _asteroidPool.Objects)
            {
                if (asteroid.isActiveAndEnabled)
                    return false;
            }

            return true;
        }
    }
}