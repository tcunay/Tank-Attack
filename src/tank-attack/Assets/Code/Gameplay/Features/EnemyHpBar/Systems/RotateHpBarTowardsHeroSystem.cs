using Entitas;

namespace Code.Gameplay.Features.EnemyHpBar.Systems
{
    public class RotateHpBarTowardsHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _hpBars;
        private readonly IGroup<GameEntity> _heroes;

        public RotateHpBarTowardsHeroSystem(GameContext game)
        {
            _hpBars = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.EnemyHpBarView, GameMatcher.Enemy));
            
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity hpBar in _hpBars)
            {
                hpBar.EnemyHpBarView.transform.LookAt(hero.WorldPosition);
            }
        }
    }
}