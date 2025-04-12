using System;
using System.Linq;
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

            return vehicleSetup.Kind switch
            {
                VehicleKind.Tank => CreateTank(vehicleSetup),
                VehicleKind.Helicopter => CreateHelicopter(vehicleSetup),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private GameEntity CreateHelicopter(VehicleSetup vehicleSetup)
        {
            return CreateVehicle(vehicleSetup)
                .With(x => x.isHelicopter = true);
        }

        private GameEntity CreateTank(VehicleSetup vehicleSetup)
        {
            return CreateVehicle(vehicleSetup)
                .With(x => x.isTank = true);
        }

        private GameEntity CreateVehicle(VehicleSetup vehicleSetup)
        {
            Transform startPoint = vehicleSetup.MoveSetup.StartPoint;
            VehicleConfig vehicleConfig = _staticDataService.GetVehicleConfig(vehicleSetup.Kind);
            
            return CreateEntity.Empty(_identifierService.Next())
                .AddMaxHp(vehicleSetup.MaxHp)
                .AddWorldPosition(startPoint.position)
                .AddWorldRotation(startPoint.rotation)
                .AddViewPrefab(vehicleConfig.Prefab)
                .AddVehicleTypeId(vehicleSetup.Kind)
                .AddSpeed(vehicleSetup.MoveSetup.Speed)
                .AddWayPointsMove(vehicleSetup.MoveSetup.WayPoints.Select(x => x.position).ToArray())
                .AddWayPointsMoveIndex(0)
                .AddArrivalThreshold(0.5f)//(vehicleSetup.MoveSetup.ArrivalThreshold)
                .AddRotationSpeed(3)
                .With(x => x.isMoving = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isEnemy = true);
            
        }
    }
}