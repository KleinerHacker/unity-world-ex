using System.Linq;
using UnityEditor;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Editor.scene_system.world_ex.Scripts.Editor
{
    public static class EditorAction
    {
        #region Open World Group

        [MenuItem("Assets/Open World Group/One", false, 0)]
        public static void OpenWorldGroupOne()
        {
            LoadWorldGroup(WorldSceneGroup.One);
        }

        [MenuItem("Assets/Open World Group/One", true, 0)]
        public static bool CanOpenWorldGroupOne()
        {
            return Selection.activeObject is WorldAsset;
        }

        [MenuItem("Assets/Open World Group/Two", false, 0)]
        public static void OpenWorldGroupTwo()
        {
            LoadWorldGroup(WorldSceneGroup.Two);
        }

        [MenuItem("Assets/Open World Group/Two", true, 0)]
        public static bool CanOpenWorldGroupTwo()
        {
            return Selection.activeObject is WorldAsset;
        }
        
        [MenuItem("Assets/Open World Group/Three", false, 0)]
        public static void OpenWorldGroupThree()
        {
            LoadWorldGroup(WorldSceneGroup.Three);
        }

        [MenuItem("Assets/Open World Group/Three", true, 0)]
        public static bool CanOpenWorldGroupThree()
        {
            return Selection.activeObject is WorldAsset;
        }

        #endregion
        
        [MenuItem("Assets/Open Runtime World", false, -1)]
        public static void OpenRuntimeWorldThree()
        {
            LoadWorldGroup(null, true);
        }

        [MenuItem("Assets/Open Runtime World", true, -1)]
        public static bool CanOpenRuntimeWorldThree()
        {
            return Selection.activeObject is WorldAsset;
        }

        private static void LoadWorldGroup(WorldSceneGroup? group, bool loadRuntime = false)
        {
            var world = Selection.activeObject as WorldAsset;
            var scenes = group == null ? world.Scenes : world.Scenes.Where(x => x.Group == group || x.Group == WorldSceneGroup.All).ToArray();
            if (scenes.Length <= 0)
            {
                EditorUtility.DisplayDialog("Open World Group", "No scenes are associated to this world group", "OK");
                return;
            }

            EditorActionUtils.LoadScenes(scenes, loadRuntime);
        }
    }
}