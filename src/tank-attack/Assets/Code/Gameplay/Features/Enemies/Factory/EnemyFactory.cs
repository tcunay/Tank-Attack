using System.Collections.Generic;
using System.Linq;
using Code.Common.Collections;
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

            CircularLinkedList<Vector3> wayPoints =
                new CircularLinkedList<Vector3>(vehicleSetup.MoveSetup.WayPoints.Select(x => x.position));

            CircularNode<Vector3> wayPointsFirst = wayPoints.First;

            return CreateEntity.Empty(_identifierService.Next())
                .AddWorldPosition(startPoint.position)
                .AddRotation(startPoint.rotation.eulerAngles)
                .AddViewPrefab(vehicleConfig.Prefab)
                .AddVehicleTypeId(vehicleSetup.Kind)
                .AddSpeed(vehicleSetup.MoveSetup.Speed)
                .AddWayPointsMove(wayPointsFirst)
                .AddArrivalThreshold(vehicleSetup.MoveSetup.ArrivalThreshold)
                .With(x => x.isMoving = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isEnemy = true);
        }
    }
}