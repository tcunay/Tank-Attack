using Code.Gameplay.Armaments.Factory;
using Code.Gameplay.Armaments.Models;
using Code.Gameplay.Armaments.Services;
using Code.Gameplay.Armaments.Setup;
using Code.Gameplay.Cameras.Factory;
using Code.Gameplay.GameOver.Services;
using Code.Gameplay.Hero.Factory;
using Code.Gameplay.Input;
using Code.Gameplay.Levels;
using Code.Gameplay.Services;
using Code.Gameplay.Vehicle.Factory;
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
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
            Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();
            Container.Bind<IVehicleFactory>().To<VehicleFactory>().AsSingle();
            Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
        }
        
        private void BindGameplayServices()
        {
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
            Container.Bind<IShootService>().To<ShootService>().AsSingle();
            Container.BindInterfacesTo<InputService>().AsSingle();
            Container.BindInterfacesTo<BulletsLifeCycleService>().AsSingle();
            Container.BindInterfacesTo<GameOverOnOutOfBulletsService>().AsSingle();
        }
    }
}