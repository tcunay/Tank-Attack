using Code.Gameplay.Features.Vehicle.Setup;
using Code.Gameplay.Levels.Setup;
using UnityEngine;

namespace Code.Gameplay.Levels
{
    public class LevelDataProvider : ILevelDataProvider
    {
        public Vector3 StartPoint { get; private set; }
        public VehicleSetup[] MoveSetups { get; private set; }
        public LevelConfig LevelConfig { get; private set; }

        public void SetStartPoint(Vector3 startPoint)
        {
            StartPoint = startPoint;
        }

        public void SetMoveSetups(VehicleSetup[] moveSetups)
        {
            MoveSetups = moveSetups;
        }

        public void SetLevelConfig(LevelConfig levelConfig)
        {
            LevelConfig = levelConfig;
        }
    }
}