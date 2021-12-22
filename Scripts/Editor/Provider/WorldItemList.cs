using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace UnityWorldEx.Editor.scene_system.world_ex.Scripts.Editor.Provider
{
    public sealed class WorldItemList : ReorderableList
    {
        private const float LeftMargin = 15f;
        private const float BottomMargin = 2f;
        private const float ColumnSpace = 5f;

        private const float KeyWidth = 300f;
        private const float UnloadWidth = 30f;
        private const float CommonWidth = KeyWidth + UnloadWidth;

        public WorldItemList(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
        {
            drawHeaderCallback += DrawHeaderCallback;
            drawElementCallback += DrawElementCallback;
        }

        private void DrawHeaderCallback(Rect rect)
        {
            var pos = new Rect(rect.x + LeftMargin, rect.y, KeyWidth, rect.height);
            EditorGUI.LabelField(pos, "Identifier");

            var sceneWidth = rect.width - (CommonWidth + LeftMargin);
            pos = new Rect(rect.x + LeftMargin + KeyWidth, rect.y, sceneWidth, rect.height);
            EditorGUI.LabelField(pos, "World");

            pos = new Rect(rect.x + LeftMargin + KeyWidth + sceneWidth, rect.y, UnloadWidth, rect.height);
            EditorGUI.LabelField(pos, new GUIContent("NU", "Never Unload World"));
        }

        private void DrawElementCallback(Rect rect, int i, bool isactive, bool isfocused)
        {
            var property = serializedProperty.GetArrayElementAtIndex(i);
            var identifierProperty = property.FindPropertyRelative("identifier");
            var sceneProperty = property.FindPropertyRelative("world");
            var neverUnloadProperty = property.FindPropertyRelative("neverUnloadWorld");

            var pos = new Rect(rect.x, rect.y, KeyWidth - ColumnSpace, rect.height - BottomMargin);
            EditorGUI.PropertyField(pos, identifierProperty, GUIContent.none);

            var sceneWidth = rect.width - CommonWidth;
            pos = new Rect(rect.x + KeyWidth, rect.y, sceneWidth - ColumnSpace, rect.height - BottomMargin);
            EditorGUI.PropertyField(pos, sceneProperty, GUIContent.none);

            pos = new Rect(rect.x + KeyWidth + sceneWidth, rect.y, UnloadWidth - ColumnSpace, rect.height - BottomMargin);
            EditorGUI.PropertyField(pos, neverUnloadProperty, GUIContent.none);
        }
    }
}