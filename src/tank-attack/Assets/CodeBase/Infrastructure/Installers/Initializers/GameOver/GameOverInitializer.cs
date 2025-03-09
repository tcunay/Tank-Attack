using System;
using CodeBase.Infrastructure.States.GameStates.Battle;
using CodeBase.Infrastructure.States.GameStates.GameOver;
using CodeBase.Infrastructure.States.GameStates.Home;
using CodeBase.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Infrastructure.Installers.Initializers.GameOver
{
    public class GameOverInitializer : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] private Button _goHomeButton;
        [SerializeField] private Button _restartButton;
        
        private IGameStateMachine _stateMachine;

        [Inject]
        private void Construct(IGameStateMachine stateMachine)
        {
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
            _stateMachine.Enter<LoadingBattleState>();
        }

        private void GoHome()
        {
            _stateMachine.Enter<LoadingHomeScreenState>();
        }
    }
}