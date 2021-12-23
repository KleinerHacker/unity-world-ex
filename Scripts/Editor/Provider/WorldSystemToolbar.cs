using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Editor.scene_system.world_ex.Scripts.Editor.Provider
{
    [InitializeOnLoad]
    public static class WorldSystemToolbar
    {
        private static readonly WorldSystemSettings WorldSystemSettings;
        private static readonly SerializedObject SerializedObject;

        private static readonly SerializedProperty UseSystemProperty;
        
        static WorldSystemToolbar()
        {
            WorldSystemSettings = WorldSystemSettings.Singleton;
            SerializedObject = WorldSystemSettings.SerializedSingleton;

            UseSystemProperty = SerializedObject.FindProperty("useSystem");
            
            ToolbarExtender.RightToolbarGUI.Add(OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
            SerializedObject.Update();

            GUILayout.FlexibleSpace();
            
            GUILayout.Space(5f);

            UseSystemProperty.boolValue = GUILayout.Toggle(UseSystemProperty.boolValue, "Use World System", ToolbarStyles.toggleStyle);
            
            SerializedObject.ApplyModifiedProperties();
        }

        private static class ToolbarStyles
        {
            public static readonly GUIStyle toggleStyle;

            static ToolbarStyles()
            {
                toggleStyle = new GUIStyle("Toggle")
                {
                    fontSize = 12,
                    alignment = TextAnchor.MiddleLeft,
                    imagePosition = ImagePosition.TextOnly,
                    fontStyle = FontStyle.Normal,
                    fixedHeight = 20f,
                    wordWrap = false,
                    margin = new RectOffset(5, 5, 5, 5)
                };
            }
        }
    }
}