using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class BulletCounterSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _bulletCounters;
        private readonly IGroup<GameEntity> _heroes;

        public BulletCounterSystem(GameContext game)
        {
            _bulletCounters = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.BulletCounter));
            
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.CurrentBulletsCount));
        }

        public void Execute()
        {
            foreach (GameEntity bulletCounter in _bulletCounters)
            foreach (GameEntity hero in _heroes)
            {
                bulletCounter.BulletCounter.text = hero.CurrentBulletsCount.ToString();
            }
        }
    }
}