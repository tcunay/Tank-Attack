using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Levels.Setup;
using UnityEngine;

namespace Code.Gameplay.Levels
{
  public interface ILevelDataProvider
  {
    Transform StartPoint { get; }
    EnemySetup[] EnemySetups { get; }
    LevelConfig LevelConfig { get; }
    void SetStartPoint(Transform startPoint);
    void SetEnemySetups(EnemySetup[] moveSetups);
    void SetLevelConfig(LevelConfig levelConfig);
  }
}