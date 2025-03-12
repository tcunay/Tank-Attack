using Code.Common.Extensions;
using Code.Gameplay;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Code.Meta.UI;

namespace Code.Infrastructure.States.GameStates.Battle
{
    public class BattleLoopState : EndOfFrameExitState
    {
        private readonly ISystemFactory _systems;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly GameContext _gameContext;
        private BattleFeature _battleFeature;

        public BattleLoopState(ISystemFactory systems, LoadingCurtain loadingCurtain, GameContext gameContext)
        {
            _systems = systems;
            _loadingCurtain = loadingCurtain;
            _gameContext = gameContext;
        }
    
        public override void Enter()
        {
            _battleFeature = _systems.Create<BattleFeature>();
            _battleFeature.Initialize();
            _loadingCurtain.Hide();
        }

        protected override void OnUpdate()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        protected override void ExitOnEndOfFrame()
        { 
            _battleFeature.Clear(DestructEntities);
            _battleFeature = null;
        }
    
        private void DestructEntities()
        {
            foreach (GameEntity entity in _gameContext.GetEntities())
            {
                entity.isDestructed = true;
            }
        }
    }
}