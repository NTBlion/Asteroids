using _Game.Scripts.Shooting;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure
{
    public class BulletSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private BulletSpawner _bullerSpawner;
        
        public override void InstallBindings()
        {
            Container.Bind<BulletSpawner>().FromInstance(_bullerSpawner).AsSingle();
        }
    }
}