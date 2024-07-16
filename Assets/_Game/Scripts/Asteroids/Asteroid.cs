using System;
using _Game.Scripts.Character;
using _Game.Scripts.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Asteroids
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _minForce;
        [SerializeField] private float _maxForce;

        private bool _canSplit = true;

        private Pool<Asteroid> _pool;

        public event Action<Asteroid> Splitted;

        public void Init(Pool<Asteroid> pool)
        {
            _pool = pool;
        }

        private void OnEnable()
        {
            transform.localScale = Vector3.one;

            _rigidbody.AddForce(new Vector2(Random.Range(_minForce, _maxForce), Random.Range(_minForce, _maxForce)),
                ForceMode2D.Impulse);
        }

        private void OnDisable()
        {
            _canSplit = true;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out Health health))
                health.TakeDamage();

            if (_canSplit)
            {
                Splitted?.Invoke(this);
                _canSplit = false;
            }

            _pool.Disable(this);
        }
    }
}