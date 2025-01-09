using Code.Gameplay.Levels;
using CodeBase.Gameplay.Cameras.Provider;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        public Transform HeroPosition;
        private ILevelDataProvider _levelDataProvider;
        private ICameraProvider _cameraProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _levelDataProvider = levelDataProvider;
        }
        
        public void Initialize()
        {
            _levelDataProvider.SetStartPoint(HeroPosition.position);
            HeroPosition.gameObject.SetActive(false);
        }
    }
}