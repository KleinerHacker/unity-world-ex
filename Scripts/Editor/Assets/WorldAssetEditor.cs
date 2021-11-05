using UnityEditor;
using UnityEditorEx.Editor.editor_ex.Scripts._90_Editor;
using UnityEditorInternal;
using UnityEngine;
using UnityWorldEx.Runtime.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Editor.world_ex.Scripts.Editor.Assets
{
    [CustomEditor(typeof(WorldAsset))]
    public sealed class WorldAssetEditor : ExtendedEditor
    {
        private ReorderableList _sceneDataList;

        private void OnEnable()
        {
            var scenes = serializedObject.FindProperty("scenes");

            _sceneDataList = BuildReordableList(scenes, "Scene Data", (EditorGUIUtility.singleLineHeight + 3) * 4, (property, rect, index, active, focused) =>
            {
                var sceneProperty = property.FindPropertyRelative("scene");
                var activeSceneProperty = property.FindPropertyRelative("activeScene");
                var loadingBehaviorProperty = property.FindPropertyRelative("loadingBehavior");
                var groupingProperty = property.FindPropertyRelative("group");

                rect.y += 3;
                var sceneName = sceneProperty.stringValue.Substring(sceneProperty.stringValue.LastIndexOf('/') + 1);
                var orig = EditorStyles.label.fontStyle;
                EditorStyles.label.fontStyle = FontStyle.Bold;
                EditorGUI.LabelField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                    new GUIContent(sceneName));
                EditorStyles.label.fontStyle = orig;
                rect.y += EditorGUIUtility.singleLineHeight + 3;

                EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                    sceneProperty, new GUIContent("Scene"));
                rect.y += EditorGUIUtility.singleLineHeight + 3;

                EditorGUI.PropertyField(
                    new Rect(rect.x, rect.y, rect.width / 2, EditorGUIUtility.singleLineHeight),
                    activeSceneProperty, new GUIContent("Active Scene")
                );
                EditorGUI.PropertyField(
                    new Rect(rect.x + rect.width / 2, rect.y, rect.width / 2, EditorGUIUtility.singleLineHeight),
                    loadingBehaviorProperty, new GUIContent("Loading Behavior")
                );
                rect.y += EditorGUIUtility.singleLineHeight + 3;
                
                EditorGUI.PropertyField(
                    new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                    groupingProperty, new GUIContent("Grouping (optional, editor only)")
                );
                rect.y += EditorGUIUtility.singleLineHeight + 3;
            });
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            _sceneDataList.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }
    }
}