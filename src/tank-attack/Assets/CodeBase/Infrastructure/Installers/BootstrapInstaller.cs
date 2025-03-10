using Code.Gameplay.Levels;
using CodeBase.Gameplay.Armaments.Factory;
using CodeBase.Gameplay.Armaments.Services;
using CodeBase.Gameplay.Cameras.Factory;
using CodeBase.Gameplay.Cameras.Provider;
using CodeBase.Gameplay.Hero.Factory;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Levels;
using CodeBase.Gameplay.StaticData;
using CodeBase.Gameplay.Time;
using CodeBase.Gameplay.Vehicle.Factory;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Common;
using CodeBase.Infrastructure.Loading;
using CodeBase.Infrastructure.States.Factory;
using CodeBase.Infrastructure.States.GameStates;
using CodeBase.Infrastructure.States.GameStates.Battle;
using CodeBase.Infrastructure.States.GameStates.GameOver;
using CodeBase.Infrastructure.States.GameStates.Home;
using CodeBase.Infrastructure.States.StateMachine;
using CodeBase.Meta.UI;
using RSG;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _curtainPrefab;
        
        public override void InstallBindings()
        {
            BindInitializeService();
            BindStaticData();
            BindServices();
            BindFactories();
            BindGameplayServices();
            BindStateMachine();
            BindStates();
            BindLoadingCurtain();
        }

        private void BindStaticData()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        }

        private void BindInitializeService()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingHomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BootBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingGameOverState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverLoopState>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
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