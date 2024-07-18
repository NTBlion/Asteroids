using _Game.Scripts.Character;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;

        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(_player).AsSingle();
        }
    }
}