using Code.Gameplay.Levels;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        public Transform HeroPosition;
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
        }
        
        public void Initialize()
        {
            _levelDataProvider.SetStartPoint(HeroPosition.position);
            HeroPosition.gameObject.SetActive(false);
        }
    }
}