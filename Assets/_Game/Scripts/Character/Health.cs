using System;
using UnityEngine;
using UniRx;

namespace _Game.Scripts.Character
{
    public class Health : MonoBehaviour
    {
        private const int Damage = 1;

        [SerializeField] private int _maxHealth;
        
        private ReactiveProperty<int> _currentHealth = new ReactiveProperty<int>();
        private ReactiveProperty<bool> _isDead = new ReactiveProperty<bool>(false);
        
        public ReactiveProperty<int> CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;
        public ReactiveProperty<bool> IsDead => _isDead;

        private void OnValidate()
        {
            _currentHealth.Value = _maxHealth;
        }

        public void TakeDamage()
        {
            _currentHealth.Value -= Damage;

            if (_currentHealth.Value <= 0)
                _isDead.Value = true;
        }
    }
}