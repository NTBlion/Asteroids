using System.Collections.Generic;
using _Game.Scripts.Character;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private RectTransform _container;

        private Health _health;
        private List<GameObject> _lives;

        [Inject]
        private void Construct(Health health)
        {
            _health = health;
        }
        
        private void Awake()
        {
            _lives = new List<GameObject>();
        }

        private void OnEnable()
        {
            _health.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void Start()
        {
            for (int i = 0; i < _health.MaxHealth; i++)
            {
                var prefab = Instantiate(_prefab, _container);
                _lives.Add(prefab);
            }
        }

        private void OnHealthChanged()
        {
            Destroy(_lives[0]);
            _lives.Remove(_lives[0]);
        }
    }
}