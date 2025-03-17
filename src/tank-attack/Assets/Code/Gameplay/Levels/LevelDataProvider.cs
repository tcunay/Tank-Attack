using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Levels.Setup;
using UnityEngine;

namespace Code.Gameplay.Levels
{
    public class LevelDataProvider : ILevelDataProvider
    {
        public Transform StartPoint { get; private set; }
        public EnemySetup[] EnemySetups { get; private set; }
        public LevelConfig LevelConfig { get; private set; }

        public void SetStartPoint(Transform startPoint)
        {
            StartPoint = startPoint;
        }

        public void SetEnemySetups(EnemySetup[] enemySetups)
        {
            EnemySetups = enemySetups;
        }

        public void SetLevelConfig(LevelConfig levelConfig)
        {
            LevelConfig = levelConfig;
        }
    }
}