using UnityEngine;

namespace CodeBase.Gameplay.Shooter.Factory
{
    public interface IShooterFactory
    {
        GameObject CreateShooter(Vector3 at);
    }
}