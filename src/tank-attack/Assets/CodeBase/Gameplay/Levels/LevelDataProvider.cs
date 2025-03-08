using Code.Gameplay.Levels;
using Code.Gameplay.Levels.Setup;
using CodeBase.Gameplay.Armaments.Setup;
using CodeBase.Gameplay.Vehicle.Setup;
using UnityEngine;

namespace CodeBase.Gameplay.Levels
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