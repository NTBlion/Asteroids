using _Game.Scripts.Asteroids;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure.Installers
{
    public class AsteroidSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private AsteroidSpawner _spawner;
        
        public override void InstallBindings()
        {
            Container.Bind<AsteroidSpawner>().FromInstance(_spawner).AsSingle();
        }
    }
}