using UnityEditor;
using UnityEngine;

namespace Code.Build.Editor
{
    [CustomEditor(typeof(AdditionalBuildSettings))]
    public class AdditionalBuildSettingsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var settings = (AdditionalBuildSettings)target;

            if(GUILayout.Button("Apply", GUILayout.Height(40)))
            {
                Apply(settings);
            }
        
        }
        
        private void Apply(AdditionalBuildSettings settings)
        {
            if (settings.IsDebugEnvironment)
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