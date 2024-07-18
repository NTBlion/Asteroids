using System.Collections;
using _Game.Scripts.Character;
using _Game.Scripts.Pool;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Game.Scripts.UFO
{
    public class UfoSpawner : MonoBehaviour
    {
        [SerializeField] private Ufo _ufo;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private Transform _container;
        [SerializeField] private float _timeBeforeSpawn;
        [SerializeField] private Transform[] _spawnPoints;

        private Pool<Ufo> _pool;
        private Player _player;

        public Ufo Ufo => _ufo;

        public int PoolCapacity => _poolCapacity;

        public Transform Container => _container;
        
        [Inject]
        private void Construct(Player player, Pool<Ufo> pool)
        {
            _player = player;
            _pool = pool;
        }

        public IEnumerator StartSpawn()
        {
            while (true)
            {
                var ufo = _pool.EnableObject();
                ufo.Init(_player, _pool);
                ufo.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;

                yield return new WaitForSeconds(_timeBeforeSpawn);
            }
        }
    }
}