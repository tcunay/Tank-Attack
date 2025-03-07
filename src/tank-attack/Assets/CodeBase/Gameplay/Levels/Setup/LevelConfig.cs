using CodeBase.Gameplay.Armaments.Setup;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Gameplay.Levels.Setup
{
    [CreateAssetMenu(fileName = "levelConfig", menuName = "TankAttack/Level Config")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private int _levelNumber;
        [SerializeField] private AssetReference _sceneReference;
        [SerializeField] private ArmamentSetup _armamentSetup;

        public int LevelNumber => _levelNumber;
        public AssetReference SceneReference => _sceneReference;
        public ArmamentSetup ArmamentSetup => _armamentSetup;
    }
}