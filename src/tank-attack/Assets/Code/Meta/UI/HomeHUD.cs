using Code.Infrastructure.States.GameStates.Battle;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI
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
            _startBattleButton.onClick.AddListener(EnterBattleState);
        }

        private void OnDestroy()
        {
            _startBattleButton.onClick.RemoveListener(EnterBattleState);
        }

        private void EnterBattleState() => 
            _stateMachine.Enter<BootBattleState, int>(1);
    }
}