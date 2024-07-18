using _Game.Scripts.Character;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure.Installers
{
    public class HealthInstaller : MonoInstaller
    {
        [SerializeField] private Health _health;
        
        public override void InstallBindings()
        {
            Container.Bind<Health>().FromInstance(_health).AsSingle();
        }
    }
}