using System;
using UnityEngine;

namespace CodeBase.Gameplay.Armaments.Services
{
    public interface IShootService
    {
        void Shoot(Vector3 at, Vector3 direction);
    }
}