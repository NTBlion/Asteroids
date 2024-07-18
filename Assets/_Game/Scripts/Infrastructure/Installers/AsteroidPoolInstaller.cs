using _Game.Scripts.Asteroids;
using _Game.Scripts.Pool;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure.Installers
{
    public class AsteroidPoolInstaller : MonoInstaller
    {
        [SerializeField] private AsteroidSpawner _spawner;

        private Pool<Asteroid> _pool;

        public override void InstallBindings()
        {
            Container.Bind<Pool<Asteroid>>().FromNew().AsSingle()
                .WithArguments(_spawner.Asteroid, _spawner.PoolCapacity, _spawner.Container);
        }
    }
}