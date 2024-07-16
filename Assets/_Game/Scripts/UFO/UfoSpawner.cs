using System.Collections;
using _Game.Scripts.Character;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.UFO
{
    public class UfoSpawner : MonoBehaviour
    {
        [SerializeField] private Ufo _ufo;
        [SerializeField] private float _timeBeforeSpawn;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Transform _container;
        
        private Player _player;

        public void Init(Player player)
        {
            _player = player;
        }

        public IEnumerator StartSpawn()
        {
            while (true)
            {
                var ufo = Instantiate(_ufo, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position,
                    quaternion.identity,
                    _container);
                ufo.Init(_player);

                yield return new WaitForSeconds(_timeBeforeSpawn);
            }
        }
    }
}