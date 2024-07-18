using System;
using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _immortalTime;
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private Health _health;

        public event Action Destroyed;

        [Inject] 
        private void Construct(Health health)
         {
             _health = health;
         }

        private void OnEnable()
        {
            _health.CurrentHealth.Subscribe(OnHealthChanged).AddTo(this);
        }

        private void OnDisable()
        {
            Destroyed?.Invoke();
        }

        private void OnHealthChanged(int value)
        {
            value = 0;
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