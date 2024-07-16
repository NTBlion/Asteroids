using _Game.Scripts.Character;
using _Game.Scripts.Pool;
using _Game.Scripts.Scores;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.Asteroids
{
    public class SmallAsteroid : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _minForce;
        [SerializeField] private float _maxForce;
        [SerializeField] private Score _score;

        private Pool<SmallAsteroid> _pool;

        public void Init(Pool<SmallAsteroid> pool, Score score)
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
            {
                health.TakeDamage();
            }
        
            _score.AddScore();
            _pool.Disable(this);
        }
    }
}