using Code.Gameplay.Levels;
using CodeBase.Gameplay.Armaments.Services;
using CodeBase.Gameplay.Armaments.Setup;
using CodeBase.Gameplay.Cameras.Components;
using CodeBase.Gameplay.Hero.Factory;
using CodeBase.Gameplay.Vehicle.Setup;
using CodeBase.Infrastructure.States.GameStates;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<ArmamentSetup>().FromInstance(_levelDataProvider.LevelConfig.ArmamentSetup).AsSingle();
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
            Container.Bind<IBulletMagazine>().To<BulletMagazine>().AsSingle();
        }
    }
}