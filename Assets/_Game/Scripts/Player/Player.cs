using System;
using System.Collections;
using UnityEngine;

namespace _Game.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _immortalTime;
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
    
        private Health _health;

        public Action Destroyed;

        public void Init(Health health)
        {
            _health = health;
        }
    
        private void OnEnable()
        {
            _health.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= OnHealthChanged;
            Destroyed?.Invoke();
        }
    
        private void OnHealthChanged()
        {
            transform.position = Vector3.zero;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.rotation = 0;
            StartCoroutine(BecomeImmortal());
        }

        private IEnumerator BecomeImmortal()
        {
            _collider.enabled = false;
            yield return new WaitForSeconds(_immortalTime);
            _collider.enabled = true;
        }
    }
}