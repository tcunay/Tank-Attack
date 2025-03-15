using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers.Initializers.BattleScene
{
    public class HeroInitializer : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _heroStartPosition;
        
        private ILevelDataProvider _levelDataProvider;
        private ICameraProvider _cameraProvider;

        //[Inject]
        private void Construct(ILevelDataProvider levelDataProvider, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _levelDataProvider = levelDataProvider;
        }
        
        public void Initialize()
        {
            //_levelDataProvider.SetStartPoint(_heroStartPosition.position, _heroStartPosition.rotation);
            //_heroStartPosition.gameObject.SetActive(false);
        }
    }
}