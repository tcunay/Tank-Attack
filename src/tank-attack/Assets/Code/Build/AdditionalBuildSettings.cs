using UnityEditor;
using UnityEngine;

namespace Code.Build
{
    [CreateAssetMenu(menuName = "GevArt/Build", fileName = "AdditionalBuildSettings")]
    public class AdditionalBuildSettings : ScriptableObject
    {
        [SerializeField] private bool _isDebugEnvironment;

        public void Apply()
        {
            if (_isDebugEnvironment)
            {
                AddDefineSymbol(Defines.DebugEnvironment);
            }
            else
            {
                RemoveDefineSymbol(Defines.DebugEnvironment);
            }
        }

        private static void AddDefineSymbol(string symbol)
        {
            var targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
            var defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup);

            if (!defines.Contains(symbol))
            {
                defines = $"{defines};{symbol}";
                PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, defines);
            }
        }

        private static void RemoveDefineSymbol(string symbol)
        {
            var targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
            var defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup);

            if (defines.Contains(symbol))
            {
                defines = defines.Replace($"{symbol};", "").Replace($";{symbol}", "").Replace(symbol, "");
                PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, defines);
            }
        }
    }
}