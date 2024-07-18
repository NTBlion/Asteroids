using System.Collections.Generic;
using _Game.Scripts.Character;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private RectTransform _container;

        private Health _health;
        private List<GameObject> _lives = new List<GameObject>();

        [Inject]
        private void Construct(Health health)
        {
            _health = health;
        }

        private void Start()
        {
            for (int i = 0; i < _health.MaxHealth+1; i++)
            {
                var prefab = Instantiate(_prefab, _container);
                _lives.Add(prefab);
            }

            _health.CurrentHealth.ObserveEveryValueChanged(x => x.Value).Subscribe(OnHealthChanged).AddTo(this);
        }

        private void OnHealthChanged(int value)
        {
            Destroy(_lives[0]);
            _lives.Remove(_lives[0]);
        }
    }
}