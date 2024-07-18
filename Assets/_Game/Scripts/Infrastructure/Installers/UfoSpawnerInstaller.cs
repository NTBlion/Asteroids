using _Game.Scripts.UFO;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure.Installers
{
    public class UfoSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private UfoSpawner _spawner;
        
        public override void InstallBindings()
        {
            Container.Bind<UfoSpawner>().FromInstance(_spawner).AsSingle();
        }
    }
}