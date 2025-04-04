using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public interface IEnemyFactory
    {
        GameEntity CreateEnemy(EnemySetup setup);
    }
}