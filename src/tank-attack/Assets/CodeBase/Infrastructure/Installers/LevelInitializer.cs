using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        public Transform ShooterPosition;
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
        }
        
        public void Initialize()
        {
            _levelDataProvider.SetStartPoint(ShooterPosition.position);
        }
    }
}