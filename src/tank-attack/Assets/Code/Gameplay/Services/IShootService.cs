using UnityEngine;

namespace Code.Gameplay.Services
{
    public interface IShootService
    {
        void Shoot(Vector3 at, Vector3 direction);
    }
}