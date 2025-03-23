using System;
using UnityEngine;

namespace Code.Gameplay.Features.Vehicle.Setup
{
    [Serializable]
    public class WayPointsMoveSetup
    {
        public float Speed = 1;
        public Transform[] WayPoints;

        public Transform StartPoint => WayPoints[0];
    }
}