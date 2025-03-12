using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Input.Services;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Common;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.GameStates.Battle;
using Code.Infrastructure.States.GameStates.GameOver;
using Code.Infrastructure.States.GameStates.Home;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
using Code.Meta.UI;
using RSG;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _curtainPrefab;
        
        public override void InstallBindings()
        {
            BindInputService();
            BindInfrastructureServices();
            BindStaticData();
            BindServices();
            BindSystemFactory();
            BindCommonServices();
            BindContexts();
            BindFactories();
            BindGameplayServices();
            BindGameplayFactories();
            BindStateMachine();
            BindStates();
            BindLoadingCurtain();
        }
        
        private void BindInputService()
        {
            Container.BindInterfacesTo<InputService>().AsSingle();
        }

        private void BindStaticData()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        }
        
        private void BindSystemFactory()
        {
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
        }

        private void BindStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingHomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BootBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleEnterState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingGameOverState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverLoopState>().AsSingle();
        }
        
        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
      
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
            Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input).AsSingle();
            Container.Bind<MetaContext>().FromInstance(Contexts.sharedInstance.meta).AsSingle();
        }
        
        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesTo<GameStateMachine>().AsSingle();
        }
        
        private void BindFactories()
        {
            
        }
        
        private void BindCommonServices()
        {
            //Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            //Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
        
        private void BindGameplayFactories()
        {
            Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();

            /*Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<IArmamentFactory>().To<ArmamentFactory>().AsSingle();
            Container.Bind<IAbilityFactory>().To<AbilityFactory>().AsSingle();
            Container.Bind<IEffectFactory>().To<EffectFactory>().AsSingle();
            Container.Bind<IStatusFactory>().To<StatusFactory>().AsSingle();
            Container.Bind<ILootFactory>().To<LootFactory>().AsSingle();
            Container.Bind<IShopItemFactory>().To<ShopItemFactory>().AsSingle();*/
        }
        
        private void BindLoadingCurtain()
        {
            Container.BindInterfacesAndSelfTo<LoadingCurtain>().FromComponentInNewPrefab(_curtainPrefab).AsSingle();
        }

        public void Initialize()
        {
            Promise.UnhandledException += LogPromiseException;
            
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }

        private void LogPromiseException(object sender, ExceptionEventArgs e)
        {
            Debug.LogError(e.Exception);
        }
    }
}