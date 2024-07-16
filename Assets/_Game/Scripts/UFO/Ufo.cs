using _Game.Scripts.Character;
using _Game.Scripts.Pool;
using UnityEngine;

namespace _Game.Scripts.UFO
{
    public class Ufo : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Pool<Ufo> _pool;
        private Player _player;

        public void Init(Player player, Pool<Ufo> pool)
        {
            _player = player;
            _player.Destroyed += OnDestroyed;
            _pool = pool;
        }
        
        private void Update()
        {
            FollowPlayer();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out Health health))
                health.TakeDamage();

            _player.Destroyed -= OnDestroyed;
            _pool.Disable(this);
        }

        private void OnDestroyed()
        {
            _pool.Disable(this);
        }

        private void FollowPlayer()
        {
            transform.Translate(
                (_player.transform.position - transform.position).normalized * (_speed * Time.deltaTime));
        }
    }
}