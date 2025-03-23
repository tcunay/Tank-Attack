using UnityEngine;

namespace Code.Build
{
    [CreateAssetMenu(menuName = "GevArt/Build", fileName = "AdditionalBuildSettings")]
    public class AdditionalBuildSettings : ScriptableObject
    {
        [SerializeField] private bool _isDebugEnvironment;
        
        public bool IsDebugEnvironment => _isDebugEnvironment;
    }
}