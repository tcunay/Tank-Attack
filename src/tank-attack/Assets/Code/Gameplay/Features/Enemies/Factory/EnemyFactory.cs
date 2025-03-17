using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Vehicle.Setup;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public EnemyFactory(IIdentifierService identifierService, IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }
        
        public GameEntity CreateEnemy(EnemySetup setup)
        {
            VehicleSetup vehicleSetup = setup.VehicleSetup;
            VehicleConfig vehicleConfig = _staticDataService.GetVehicleConfig(vehicleSetup.Kind);

            Transform startPoint = vehicleSetup.MoveSetup.StartPoint;
            
            return CreateEntity.Empty(_identifierService.Next())
                .AddWorldPosition(startPoint.position)
                .AddRotation(startPoint.rotation.eulerAngles)
                .AddViewPrefab(vehicleConfig.Prefab)
                .AddVehicleTypeId(vehicleSetup.Kind)
                .AddSpeed(vehicleSetup.MoveSetup.Speed)
                .AddWayPointsMove(vehicleSetup.MoveSetup.WayPoints)
                .With(x => x.isEnemy = true);
        }
    }
}