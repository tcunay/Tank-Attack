using Code.Gameplay.Features.Vehicle.Setup;
using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers.Initializers.BattleScene
{
    public class VehicleInitializer : MonoBehaviour, IInitializable
    {
        public VehicleSetup[] MoveSetups;
        
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
        }
        
        public void Initialize()
        {
            //_levelDataProvider.SetEnemySetups(MoveSetups);
        }
    }
}