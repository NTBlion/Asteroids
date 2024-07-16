using System.Collections;
using _Game.Scripts.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Asteroid
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoint;
        [SerializeField] private Asteroid _asteroid;
        [SerializeField] private SmallAsteroid _smallAsteroid;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private Transform _container;
        [SerializeField] private int _splitCount;
        [SerializeField] private Score.Score _score;
    
        private Pool<Asteroid> _asteroidPool;
        private Pool<SmallAsteroid> _smallAsteroidPool;

        public SmallAsteroid SmallAsteroid => _smallAsteroid;

        public Asteroid Asteroid => _asteroid;

        public int PoolCapacity => _poolCapacity;

        public Transform Container => _container;

        public void Init(Pool<Asteroid> asteroidPool, Pool<SmallAsteroid> smallAsteroidPool, Score.Score score)
        {
            _asteroidPool = asteroidPool;
            _smallAsteroidPool = smallAsteroidPool;
            _score = score;
        }
    
        public IEnumerator StartSpawn()
        {
            while (true)
            {
                Spawn(Random.Range(1, 11));
                yield return new WaitUntil(IsAsteroidsActive);
            }
        }

        private void Spawn(int spawnCount)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                var asteroid = _asteroidPool.EnableObject();
                asteroid.Init(_asteroidPool, _score);
                asteroid.Splitted += Split;

                asteroid.transform.position = _spawnPoint[Random.Range(0, _spawnPoint.Length)].position;
            }
        }

        private void Split(Asteroid asteroid)
        {
            for (int i = 0; i < _splitCount; i++)
            {
                var smallAsteroid = _smallAsteroidPool.EnableObject();
                smallAsteroid.Init(_smallAsteroidPool, _score);

                smallAsteroid.transform.position = asteroid.transform.position;
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