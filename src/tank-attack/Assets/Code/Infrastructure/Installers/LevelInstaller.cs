using Code.Gameplay.Cameras.Factory;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Armaments.Models;
using Code.Gameplay.Features.Armaments.Setup;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Vehicle.Factory;
using Code.Gameplay.GameOver.Services;
using Code.Gameplay.Input;
using Code.Gameplay.Input.Services;
using Code.Gameplay.Levels;
using Code.Gameplay.Services;
using Code.Infrastructure.Common;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller, ICoroutineRunner
    {
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
        }
        
        public override void InstallBindings()
        {
            return;
            BindSetups();
            BindModels();
            BindFactories();
            BindGameplayServices();
        }

        private void BindSetups()
        {
            Container.Bind<ArmamentSetup>().FromInstance(_levelDataProvider.LevelConfig.ArmamentSetup).AsSingle();
        }

        private void BindModels()
        {
            Container.BindInterfacesTo<WeaponMagazine>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<IVehicleFactory>().To<VehicleFactory>().AsSingle();
        }
        
        private void BindGameplayServices()
        {
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
            Container.Bind<IShootService>().To<ShootService>().AsSingle();
            Container.BindInterfacesTo<GameOverOnOutOfBulletsService>().AsSingle();
        }
    }
}