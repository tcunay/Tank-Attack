using System;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.GameStates.Battle;
using Code.Infrastructure.States.GameStates.GameOver;
using Code.Infrastructure.States.GameStates.Home;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Infrastructure.Installers.Initializers.WinLevel
{
    public class WinLevelInitializer : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] private Button _goHomeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _nextButton;
        
        private IGameStateMachine _stateMachine;
        private ILevelDataProvider _levelDataProvider;
        private IStaticDataService _staticDataService;

        [Inject]
        private void Construct(IGameStateMachine stateMachine, ILevelDataProvider levelDataProvider, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _levelDataProvider = levelDataProvider;
            _stateMachine = stateMachine;
        }
        
        public void Initialize()
        {
            _goHomeButton.onClick.AddListener(GoHome);
            _restartButton.onClick.AddListener(RestartBattle);
            _nextButton.onClick.AddListener(NextBatle);


            _nextButton.gameObject.SetActive(ExistNextLevel());
            
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
        
        private void NextBatle()
        {
            int currentLevelNumber = _levelDataProvider.LevelConfig.LevelNumber;
            
            _stateMachine.Enter<LoadingBattleState, int>(currentLevelNumber + 1);
        }
        
        private bool ExistNextLevel()
        {
            bool isExist = true;
            try
            {
                _staticDataService.GetLevelConfig(_levelDataProvider.LevelConfig.LevelNumber + 1);
            }
            catch
            {
                isExist = false;
            }

            return isExist;
        }
    }
}