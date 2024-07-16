using System;
using _Game.Scripts.Character;
using _Game.Scripts.Pool;
using _Game.Scripts.Scores;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Asteroids
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _minForce;
        [SerializeField] private float _maxForce;
        [SerializeField] private Score _score;
        
        private Pool<Asteroid> _pool;

        public event Action<Asteroid> Splitted;
        
        public void Init(Pool<Asteroid> pool, Score score)
        {
            _pool = pool;
            _score = score;
        }

        private void OnEnable()
        {
            _rigidbody.AddForce(new Vector2(Random.Range(_minForce, _maxForce), Random.Range(_minForce, _maxForce)),
                ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out Health health))
                health.TakeDamage();

            _score.AddScore();
            Splitted?.Invoke(this);
            _pool.Disable(this);
        }
    }
}