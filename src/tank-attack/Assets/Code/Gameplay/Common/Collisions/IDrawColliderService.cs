using UnityEngine;

namespace Code.Gameplay.Common.Collisions
{
    public interface IDrawColliderService
    {
        void Draw(Collider collider);
    }
}