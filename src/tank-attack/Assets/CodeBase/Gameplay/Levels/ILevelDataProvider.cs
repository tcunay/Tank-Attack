using CodeBase.Gameplay.Vehicle.Setup;
using UnityEngine;

namespace Code.Gameplay.Levels
{
  public interface ILevelDataProvider
  {
    Vector3 StartPoint { get; }
    VehicleSetup[] MoveSetups { get; }
    void SetStartPoint(Vector3 startPoint);
    void SetMoveSetups(VehicleSetup[] moveSetups);
  }
}