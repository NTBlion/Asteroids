using _Game.Scripts.Pool;
using _Game.Scripts.UFO;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure.Installers
{
    public class UfoPoolInstaller : MonoInstaller
    {
        [SerializeField] private UfoSpawner _spawner;

        private Pool<Ufo> _pool;

        public override void InstallBindings()
        {
            Container.Bind<Pool<Ufo>>().FromNew().AsSingle()
                .WithArguments(_spawner.Ufo, _spawner.PoolCapacity, _spawner.Container);
        }
    }
}