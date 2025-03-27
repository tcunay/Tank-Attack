using System.Collections.Generic;
using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Aim.Systems
{
    public class InitAimSystem : IInitializeSystem
    {
        private readonly List<GameEntity> _aimBuffer = new();
        
        private readonly IGroup<GameEntity> _aims;
        private readonly IGroup<GameEntity> _cameras;

        public InitAimSystem(GameContext game)
        {
            _aims = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Aim
                ));
        }

        public void Initialize()
        {
            foreach (GameEntity aim in _aims.GetEntities(_aimBuffer))
            {
                aim.AddDetectionTime(1.5f)
                    .AddWorldPosition(Vector3.zero)
                    .AddDirection(Vector3.zero)
                    .AddLayerMask(CollisionLayer.Enemy.AsMask())
                    .AddMaxDetectingTime(2f);
            }
        }
    }
}