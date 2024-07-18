using _Game.Scripts.Shooting;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure
{
    public class LaserInstaller : MonoInstaller
    {
        [SerializeField] private Laser _laser;

        public override void InstallBindings()
        {
            Container.Bind<Laser>().FromInstance(_laser).AsSingle();
        }
    }
}