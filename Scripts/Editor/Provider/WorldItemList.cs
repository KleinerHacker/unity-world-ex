using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnitySceneBase.Editor.scene_system.scene_base.Scripts.Editor.Provider;

namespace UnityWorldEx.Editor.scene_system.world_ex.Scripts.Editor.Provider
{
    public sealed class WorldItemList : ItemListBase
    {
        public WorldItemList(SerializedObject serializedObject, SerializedProperty elements) : base(serializedObject, elements)
        {
        }

        protected override void OnDrawCommonHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "World");
        }

        protected override void OnDrawCommonElement(Rect rect, int i, bool isactive, bool isfocused)
        {
            var property = serializedProperty.GetArrayElementAtIndex(i);
            var worldProperty = property.FindPropertyRelative("world");
            EditorGUI.PropertyField(rect, worldProperty, GUIContent.none);
        }
    }
}