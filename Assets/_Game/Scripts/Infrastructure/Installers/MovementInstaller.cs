using _Game.Scripts.Character;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure.Installers
{
    public class MovementInstaller : MonoInstaller
    {
        [SerializeField] private Movement _movement;

        public override void InstallBindings()
        {
            Container.Bind<Movement>().FromInstance(_movement).AsSingle();
        }
    }
}