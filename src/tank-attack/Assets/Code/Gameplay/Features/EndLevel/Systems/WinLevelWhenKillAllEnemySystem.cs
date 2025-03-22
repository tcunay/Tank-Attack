using Code.Infrastructure.States.GameStates.GameOver;
using Code.Infrastructure.States.GameStates.WinLevel;
using Code.Infrastructure.States.StateMachine;
using Entitas;

namespace Code.Gameplay.Features.EndLevel.Systems
{
    public class WinLevelWhenKillAllEnemySystem : IExecuteSystem
    {
        private readonly IGameStateMachine _stateFactory;
        private readonly IGroup<GameEntity> _enemies;

        public WinLevelWhenKillAllEnemySystem(GameContext game, IGameStateMachine stateFactory)
        {
            _stateFactory = stateFactory;
         
            _enemies = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Enemy));
        }

        public void Execute()
        {
            if (_enemies.count <= 0)
            {
                LoadingWinState();
            }
        }

        private void LoadingWinState()
        {
            _stateFactory.Enter<LoadingWinLevelState>();
        }
    }
}