using _Game.Scripts.Shooting;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure.Installers
{
    public class BulletSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private BulletSpawner _spawner;
        
        public override void InstallBindings()
        {
            Container.Bind<BulletSpawner>().FromInstance(_spawner).AsSingle();
        }
    }
}