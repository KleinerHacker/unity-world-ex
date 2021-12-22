using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnitySceneBase.Editor.scene_system.scene_base.Scripts.Editor.Provider;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Editor.scene_system.world_ex.Scripts.Editor.Provider
{
    public sealed class WorldSettingsProvider : SceneSettingsProviderBase
    {
        #region Static Area

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new WorldSettingsProvider();
        }

        #endregion

        #region Properties

        protected override SerializedObject Settings => WorldSystemSettings.SerializedSingleton;
        protected override bool HasAnyEmptyIdentifier => WorldSystemSettings.Singleton.Items.Any(x => string.IsNullOrWhiteSpace(x.Identifier));
        protected override bool HasAnyDoubleIdentifier => WorldSystemSettings.Singleton.Items.GroupBy(x => x.Identifier).Any(x => x.Count() > 1);

        #endregion

        public WorldSettingsProvider() :
            base("Project/World System", new[] { "Scene", "System", "Tooling", "Loading", "World" })
        {
        }

        public override void OnGUI(string searchContext)
        {
#if SCENE_EX
            EditorGUILayout.HelpBox("World Extensions and Scene Extension are not compatible. Please remove one dependency from project!", MessageType.Error);
#endif

            base.OnGUI(searchContext);
        }

        protected override ReorderableList CreateItemList(SerializedObject settings, SerializedProperty itemsProperty) => new WorldItemList(settings, itemsProperty);
    }
}