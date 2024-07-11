using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    public Action<int> HealthChanged;
    
    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth);
        
        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("Died");
    }
}
