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
            var script = (AdditionalBuildSettings)target;

            if(GUILayout.Button("Apply", GUILayout.Height(40)))
            {
                script.Apply();
            }
        
        }
    }
}