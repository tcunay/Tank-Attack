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
                EnemyType.Tank => CreateTank(vehicleSetup),
                EnemyType.Helicopter => CreateHelicopter(vehicleSetup),
                EnemyType.Dron => CreateDron(vehicleSetup),
                EnemyType.BlockPost => CreateBlockPost(vehicleSetup),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private GameEntity CreateBlockPost(VehicleSetup vehicleSetup)
        {
            return CreateEnemy(vehicleSetup)
                .With(x => x.isBlockPost = true);
        }

        private GameEntity CreateHelicopter(VehicleSetup vehicleSetup)
        {
            return CreateVehicle(vehicleSetup)
                .With(x => x.isHelicopter = true);
        }
        
        private GameEntity CreateDron(VehicleSetup vehicleSetup)
        {
            return CreateVehicle(vehicleSetup)
                .With(x => x.isDron = true);
        }

        private GameEntity CreateTank(VehicleSetup vehicleSetup)
        {
            return CreateVehicle(vehicleSetup)
                .With(x => x.isTank = true);
        }

        private GameEntity CreateVehicle(VehicleSetup vehicleSetup)
        {
            return CreateEnemy(vehicleSetup)
                .AddSpeed(vehicleSetup.MoveSetup.Speed)
                .AddWayPointsMove(vehicleSetup.MoveSetup.WayPoints.Select(x => x.position).ToArray())
                .AddWayPointsMoveIndex(0)
                .AddArrivalThreshold(0.5f)
                .AddRotationSpeed(3)
                .With(x => x.isMoving = true)
                .With(x => x.isMovementAvailable = true);
        }

        private GameEntity CreateEnemy(VehicleSetup vehicleSetup)
        {
            Transform startPoint = vehicleSetup.MoveSetup.StartPoint;
            VehicleConfig vehicleConfig = _staticDataService.GetVehicleConfig(vehicleSetup.Kind);

            return CreateEntity.Empty(_identifierService.Next())
                .AddMaxHp(vehicleSetup.MaxHp)
                .AddWorldPosition(startPoint.position)
                .AddWorldRotation(startPoint.localRotation)
                .AddViewPrefab(vehicleConfig.Prefab)
                .AddVehicleTypeId(vehicleSetup.Kind)
                .With(x => x.isEnemy = true);
        }
    }
}