using _Game.Scripts.Scores;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Infrastructure.Installers
{
    public class ScoreInstaller : MonoInstaller
    {
        [SerializeField] private Score _score;

        public override void InstallBindings()
        {
            Container.Bind<Score>().FromInstance(_score).AsSingle();
        }
    }
}