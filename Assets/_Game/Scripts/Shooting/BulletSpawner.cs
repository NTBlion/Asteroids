using _Game.Scripts.Pool;
using UnityEngine;

namespace _Game.Scripts.Shooting
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private Transform _container;

        private Pool<Bullet> _pool;

        public int PoolCapacity => _poolCapacity;

        public Transform Container => _container;

        public Bullet Bullet => _bullet;

        public void Init(Pool<Bullet> pool)
        {
            _pool = pool;
        }
    
        public void Spawn()
        {
            var bullet = _pool.EnableObject();
            bullet.Init(_pool);
            bullet.transform.position = _shootPoint.position;
            bullet.transform.rotation = _shootPoint.transform.rotation;
        }
    }
}

