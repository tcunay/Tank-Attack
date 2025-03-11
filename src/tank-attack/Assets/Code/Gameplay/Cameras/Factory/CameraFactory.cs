using Code.Gameplay.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cameras.Factory
{
    public class CameraFactory : ICameraFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataService _staticData;

        public CameraFactory(IInstantiator instantiator, IStaticDataService staticData)
        {
            _instantiator = instantiator;
            _staticData = staticData;
        }
        
        public Camera CreateCamera()
        {
            return _instantiator.InstantiatePrefabForComponent<Camera>(_staticData.CameraPrefab());
        }
    }
}