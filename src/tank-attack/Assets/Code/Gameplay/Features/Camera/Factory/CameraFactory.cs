using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cameras.Factory
{
    public class CameraFactory : ICameraFactory
    {
        private readonly IIdentifierService _inIdentifierService;

        public CameraFactory(IIdentifierService inIdentifierService)
        {
            _inIdentifierService = inIdentifierService;
        }
        
        public GameEntity CreateCamera()
        {
            return CreateEntity.Empty()
                .AddId(_inIdentifierService.Next())
                .AddViewPath(AssetPath.CameraPrefabPath)
                .AddWorldPosition(Vector3.zero)
                .AddWorldRotation(Vector3.zero)
                .With(x => x.isCamera = true);
        }
    }
}