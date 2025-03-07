using System;
using CodeBase.Infrastructure.States.GameStates;
using CodeBase.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Meta.UI
{
    public class HomeHUD : MonoBehaviour
    {
        [SerializeField] private Button _startBattleButton;
        
        private const string BattleSceneName = "BattleScene";
    
        private IGameStateMachine _stateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _startBattleButton.onClick.AddListener(EnterBattleLoadingState);
        }

        private void OnDestroy()
        {
            _startBattleButton.onClick.RemoveListener(EnterBattleLoadingState);
        }

        private void EnterBattleLoadingState() => 
            _stateMachine.Enter<LoadingBattleState>();
    }
}