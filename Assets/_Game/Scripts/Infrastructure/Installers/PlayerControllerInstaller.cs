using _Game.Scripts.Character;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure.Installers
{
    public class PlayerControllerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerController _controller;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerController>().FromInstance(_controller).AsSingle();
        }
    }
}