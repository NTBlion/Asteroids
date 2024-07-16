using System;
using _Game.Scripts.Player;
using _Game.Scripts.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Asteroid
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _minForce;
        [SerializeField] private float _maxForce;
        [SerializeField] private Score.Score _score;

        public Action<Asteroid> Splitted;

        private Pool<Asteroid> _pool;

        public void Init(Pool<Asteroid> pool, Score.Score score)
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