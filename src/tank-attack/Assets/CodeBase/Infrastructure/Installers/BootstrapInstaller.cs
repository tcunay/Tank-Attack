using Code.Gameplay.Levels;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shooter.Factory;
using CodeBase.Gameplay.Time;
using CodeBase.Infrastructure.Common;
using CodeBase.Infrastructure.Loading;
using CodeBase.Infrastructure.States.Factory;
using CodeBase.Infrastructure.States.GameStates;
using CodeBase.Infrastructure.States.StateMachine;
using RSG;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindInitializeService();
            BindServices();
            BindGameplayServices();
            BindFactories();
            BindStateMachine();
            BindStates();
        }

        private void BindInitializeService()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<IInputService>()

#if UNITY_EDITOR
                .To<StandaloneInputService>()
#else
                .To<MobileInputService>()
#endif
                .AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesTo<GameStateMachine>().AsSingle();
        }
        
        private void BindFactories()
        {
            Container.Bind<IShooterFactory>().To<ShooterFactory>().AsSingle();
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