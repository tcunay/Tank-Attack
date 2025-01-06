using CodeBase.Gameplay.Vehicle.Setup;
using UnityEngine;

namespace Code.Gameplay.Levels
{
  public class LevelDataProvider : ILevelDataProvider
  {
    public Vector3 StartPoint { get; private set; }
    public VehicleSetup[] MoveSetups { get; private set; }

    public void SetStartPoint(Vector3 startPoint)
    {
      StartPoint = startPoint;
    }

    public void SetMoveSetups(VehicleSetup[] moveSetups)
    {
      MoveSetups = moveSetups;
    }
  }
}