using _Game.Scripts.Character;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure
{
    public class PlayerInputInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInput _playerInput;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerInput>().FromInstance(_playerInput).AsSingle();
        }
    }
}