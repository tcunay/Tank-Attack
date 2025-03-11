using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers.Initializers.BattleScene
{
    public class HeroInitializer : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _heroPosition;
        
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
            _levelDataProvider.SetStartPoint(_heroPosition.position);
            _heroPosition.gameObject.SetActive(false);
        }
    }
}