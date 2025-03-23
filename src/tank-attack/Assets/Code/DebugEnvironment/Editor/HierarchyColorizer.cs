using Code.Common.Extensions;
using Code.Infrastructure.Installers.Initializers.BattleScene;
using UnityEditor;
using UnityEngine;

namespace Code.DebugEnvironment.Editor
{
    [InitializeOnLoad]
    public class HierarchyColorizer
    {
        static HierarchyColorizer()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
        }

        private static void OnHierarchyGUI(int instanceID, Rect selectionRect)
        {
            GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (obj != null && obj.name.StartsWith(LevelInitializer.WaypointsDebugObject)) // Меняем цвет только для объектов с этим именем
            {
                EditorGUI.DrawRect(selectionRect, Color.green.AlphaMultiplied(0.3f));
            }
        }
    }
}