using System;
using UnityEngine;

namespace _Game.Scripts.Player
{
    public class Health : MonoBehaviour
    {
        private const int Damage = 1;
    
        [SerializeField] private int _maxHealth;
        private int _currentHealth;

        public Action HealthChanged;
        public Action Died;

        public int MaxHealth => _maxHealth;

        private void Awake()
        {
            _currentHealth = MaxHealth;
        }

        public void TakeDamage()
        {
            _currentHealth -= Damage;
            HealthChanged?.Invoke();
        
            if (_currentHealth <= 0)
                Died?.Invoke();
        }
    }
}
