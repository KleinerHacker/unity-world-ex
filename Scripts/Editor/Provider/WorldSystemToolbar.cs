using UnityEditor;
using UnityEditorEx.Editor.editor_ex.Scripts.Editor.Utils;
using UnityEngine;
using UnitySceneBase.Editor.scene_system.scene_base.Scripts.Editor;
using UnityToolbarExtender;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Editor.scene_system.world_ex.Scripts.Editor.Provider
{
    [InitializeOnLoad]
    public static class WorldSystemToolbar
    {
#if WORLD_TOOLBAR_INTEGRATION
        private static readonly WorldSystemSettings WorldSystemSettings;
        private static readonly SerializedObject SerializedObject;

        static WorldSystemToolbar()
        {
            WorldSystemSettings = WorldSystemSettings.Singleton;
            SerializedObject = WorldSystemSettings.SerializedSingleton;

            ToolbarExtender.RightToolbarGUI.Add(OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
            SerializedObject.Update();

            GUILayout.FlexibleSpace();

            GUILayout.Space(5f);

            ExtendedEditorGUILayout.SymbolField(new GUIContent("Use World System"), "PCSOFT_WORLD", ToolbarStyles.toggleStyle);
            ExtendedEditorGUILayout.SymbolField(new GUIContent("Editor World Loading"), "PCSOFT_SCENE_EDITOR_LOAD", ToolbarStyles.toggleStyle);

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
#endif
    }
}