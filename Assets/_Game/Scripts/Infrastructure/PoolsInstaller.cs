using _Game.Scripts.Asteroids;
using _Game.Scripts.Pool;
using _Game.Scripts.Shooting;
using _Game.Scripts.UFO;
using UnityEngine;
using Zenject;
using Asteroid = Zenject.Asteroids.Asteroid;

namespace _Game.Scripts.Infrastructure
{
    public class PoolsInstaller : MonoInstaller
    {
        [SerializeField] private AsteroidSpawner _asteroidSpawner;
        [SerializeField] private BulletSpawner _bulletSpawner;
        [SerializeField] private UfoSpawner _ufoSpawner;
        
        private Pool<Asteroid> _asteroid;
        private Pool<Bullet> _bullet;
        private Pool<Ufo> _ufo;

        public override void InstallBindings()
        {
            BindAsteroidPool();
            //BindBulletPool();
            //BindUfoPool();
        }

        private void BindAsteroidPool()
        {
            Container.Bind<Pool<Asteroid>>().FromNew().AsSingle().WithArguments(_asteroidSpawner.Asteroid,
                _asteroidSpawner.PoolCapacity,
                _asteroidSpawner.Container);
        }

        private void BindBulletPool()
        {
            Container.Bind<Pool<Bullet>>().FromNew().AsSingle().WithArguments(_bulletSpawner.Bullet,
                _bulletSpawner.PoolCapacity,
                _bulletSpawner.Container);
        }

        private void BindUfoPool()
        {
            Container.Bind<Pool<Ufo>>().FromNew().AsSingle()
                .WithArguments(_ufoSpawner.Ufo, _ufoSpawner.PoolCapacity, _ufoSpawner.Container);
        }
    }
}