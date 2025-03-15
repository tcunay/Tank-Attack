using Code.Gameplay.Features.Vehicle.Setup;
using Code.Gameplay.Levels.Setup;
using UnityEngine;

namespace Code.Gameplay.Levels
{
  public interface ILevelDataProvider
  {
    Transform StartPoint { get; }
    VehicleSetup[] MoveSetups { get; }
    LevelConfig LevelConfig { get; }
    void SetStartPoint(Transform startPoint);
    void SetMoveSetups(VehicleSetup[] moveSetups);
    void SetLevelConfig(LevelConfig levelConfig);
  }
}