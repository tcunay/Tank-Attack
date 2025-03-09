using Code.Gameplay.Levels;
using CodeBase.Gameplay.Armaments.Factory;
using CodeBase.Gameplay.Armaments.Models;
using CodeBase.Gameplay.Armaments.Services;
using CodeBase.Gameplay.Armaments.Setup;
using CodeBase.Gameplay.Cameras.Factory;
using CodeBase.Gameplay.GameOver.Services;
using CodeBase.Gameplay.Hero.Factory;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Services;
using CodeBase.Gameplay.Vehicle.Factory;
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
            Container.BindInterfacesTo<BulletMagazine>().AsSingle();
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
            Container.Bind<IShootService>().To<ShootService>().AsSingle();
            Container.BindInterfacesTo<InputService>().AsSingle();
            Container.BindInterfacesTo<GameOverOnMagazineEmptyService>().AsSingle();
        }
    }
}