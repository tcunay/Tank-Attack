using System;
using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.EnemyHpBar.Systems
{
    public class UpdateEnemyBarSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _enemyHpBars;

        public UpdateEnemyBarSystem(GameContext game) : base(game)
        {
            _enemyHpBars = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EnemyHpBarView,
                    GameMatcher.Enemy,
                    GameMatcher.CurrentHp
                ));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.CurrentHp);

        protected override bool Filter(GameEntity enemy) => enemy.isEnemy && 
                                                            enemy.hasEnemyHpBarView &&
                                                            enemy.hasMaxHp && enemy.hasCurrentHp && enemy.hasPrevHp &&
                                                            Math.Abs(enemy.CurrentHp - enemy.PrevHp) > float.Epsilon;

        protected override void Execute(List<GameEntity> enemies)
        {
            //foreach (GameEntity hpBar in _enemyHpBars)
            foreach (GameEntity enemy in enemies)
            {
                enemy.EnemyHpBarView.AnimateTakeDamage(enemy.MaxHp, enemy.CurrentHp, enemy.PrevHp);
            }
        }
    }
}