using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Common.PhysicsGame
{
  public interface IPhysicsService
  {
    GameEntity Raycast(Vector3 worldPosition, Vector3 direction, int layerMask, float maxDistance);
    GameEntity LineCast(Vector2 start, Vector2 end, int layerMask);
    TEntity OverlapPoint<TEntity>(Vector2 worldPosition, int layerMask) where TEntity : class;
    IEnumerable<GameEntity> RaycastAll(Vector2 worldPosition, Vector2 direction, int layerMask);
    IEnumerable<GameEntity> OverlapSphere(Vector3 position, float radius, int layerMask);
    int OverlapSphere(Vector3 worldPos, float radius, Collider[] hits, int layerMask);
    int CircleCastNonAlloc(Vector3 position, float radius, int layerMask, GameEntity[] hitBuffer);
    GameEntity SphereCast(Vector3 worldPosition, Vector3 direction, int layerMask, float radius, float maxDistance);
  }
}