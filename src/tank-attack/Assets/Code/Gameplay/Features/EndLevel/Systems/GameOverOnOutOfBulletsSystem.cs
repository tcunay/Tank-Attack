using Code.Infrastructure.States.GameStates.GameOver;
using Code.Infrastructure.States.StateMachine;
using Entitas;

namespace Code.Gameplay.Features.EndLevel.Systems
{
   public class GameOverOnOutOfBulletsSystem : IExecuteSystem
   {
      private readonly IGameStateMachine _stateFactory;
      private readonly IGroup<GameEntity> _hero;
      private readonly IGroup<GameEntity> _bullets;
      private readonly IGroup<GameEntity> _enemies;

      public GameOverOnOutOfBulletsSystem(GameContext game, IGameStateMachine stateFactory)
      {
         _stateFactory = stateFactory;
         
         _hero = game.GetGroup(GameMatcher
            .AllOf(GameMatcher.Hero, GameMatcher.CurrentBulletsCount));
         
         _enemies = game.GetGroup(GameMatcher
            .AllOf(GameMatcher.Enemy));
         
         _bullets = game.GetGroup(GameMatcher
            .AllOf(GameMatcher.Projectile));
      }

      public void Execute()
      {
         if (_bullets.count > 0)
         {
            return;
         }

         if (_enemies.count <= 0)
         {
            return;
         }
         
         foreach (GameEntity hero in _hero)
         {
            if (hero.CurrentBulletsCount <= 0)
            {
               LoadingGameOverState();
            }
         }
      }

      private void LoadingGameOverState()
      {
         _stateFactory.Enter<LoadingGameOverState>();
      }
   }
}