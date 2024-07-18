using _Game.Scripts.Pool;
using _Game.Scripts.Shooting;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure.Installers
{
    public class BulletPoolInstaller : MonoInstaller
    {
        [SerializeField] private BulletSpawner _spawner;

        private Pool<Bullet> _pool;

        public override void InstallBindings()
        {
            Container.Bind<Pool<Bullet>>().FromNew().AsSingle()
                .WithArguments(_spawner.Bullet, _spawner.PoolCapacity, _spawner.Container);
        }
    }
}