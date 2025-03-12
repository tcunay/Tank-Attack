using UnityEngine;

namespace Code.Gameplay.Features.Vehicle.Setup
{
    [CreateAssetMenu(fileName = "vehicleConfig", menuName = "TankAttack/Vehicle Config")]
    public class VehicleConfig : ScriptableObject
    {
        [SerializeField] private VehicleKind _vehicleKind;
        [SerializeField] private GameObject _prefab;

        public GameObject Prefab => _prefab;
        public VehicleKind Kind => _vehicleKind;
    }
}