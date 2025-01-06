using System;
using UnityEngine;

namespace CodeBase.Gameplay.Vehicle.Setup
{
    [Serializable]
    public class WayPointsMoveSetup
    {
        public float Speed = 1;
        public Transform[] WayPoints;
    }
}