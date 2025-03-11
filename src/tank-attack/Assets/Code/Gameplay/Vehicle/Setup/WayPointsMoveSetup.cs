using System;
using UnityEngine;

namespace Code.Gameplay.Vehicle.Setup
{
    [Serializable]
    public class WayPointsMoveSetup
    {
        public float Speed = 1;
        public Transform[] WayPoints;
    }
}