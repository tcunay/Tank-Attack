using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Vehicle.Setup
{
    [CreateAssetMenu(fileName = "vehicleConfig", menuName = "TankAttack/Vehicle Config")]
    public class VehicleConfig : ScriptableObject
    {
        [SerializeField] private VehicleKind _vehicleKind;
        [SerializeField] private EntityBehaviour _prefab;

        public EntityBehaviour Prefab => _prefab;
        public VehicleKind Kind => _vehicleKind;
    }
}