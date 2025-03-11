using Code.Gameplay.Levels;
using Code.Gameplay.Vehicle.Setup;
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
            _levelDataProvider.SetMoveSetups(MoveSetups);
        }
    }
}