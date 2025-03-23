using UnityEngine;

namespace Code.DebugEnvironment
{
    [CreateAssetMenu(menuName = "GevArt/Build", fileName = "DebugEnvironmentSettings")]
    public class DebugEnvironmentSettings : ScriptableObject
    {
        [SerializeField] private bool _isDebugEnvironment;
        
        public bool IsDebugEnvironment => _isDebugEnvironment;
    }
}