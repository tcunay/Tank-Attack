using System;
using Code.Gameplay.Levels;
using Code.Infrastructure.States.GameStates.Battle;
using Code.Infrastructure.States.GameStates.GameOver;
using Code.Infrastructure.States.GameStates.Home;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Infrastructure.Installers.Initializers.GameOver
{
    public class GameOverInitializer : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] private Button _goHomeButton;
        [SerializeField] private Button _restartButton;
        
        private IGameStateMachine _stateMachine;
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(IGameStateMachine stateMachine, ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
            _stateMachine = stateMachine;
        }
        
        public void Initialize()
        {
            _goHomeButton.onClick.AddListener(GoHome);
            _restartButton.onClick.AddListener(RestartBattle);
            
            _stateMachine.Enter<GameOverLoopState>();
        }
        
        public void Dispose()
        {
            _goHomeButton.onClick.RemoveListener(GoHome);
            _restartButton.onClick.RemoveListener(RestartBattle);
        }

        private void RestartBattle()
        {
            _stateMachine.Enter<LoadingBattleState, int>(_levelDataProvider.LevelConfig.LevelNumber);
        }

        private void GoHome()
        {
            _stateMachine.Enter<LoadingHomeScreenState>();
        }
    }
}