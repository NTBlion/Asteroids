using _Game.Scripts.Pool;
using UnityEngine;

namespace _Game.Scripts.Shooting
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _bulletLifeTime;

        private Pool<Bullet> _pool;
        private float _time;

        public void Init(Pool<Bullet> pool)
        {
            _pool = pool;
        }

        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            _time += Time.deltaTime;
            transform.Translate(Vector2.up * (_speed * Time.deltaTime));

            if (_time >= _bulletLifeTime)
            {
                _time = 0;
                _pool.Disable(this);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _time = 0;
            _pool.Disable(this);
        }
    }
}