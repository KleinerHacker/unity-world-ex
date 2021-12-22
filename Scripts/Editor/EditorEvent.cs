using UnityEditor;
using UnityEditor.Callbacks;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Editor.scene_system.world_ex.Scripts.Editor
{
    public static class EditorEvent
    {
        [OnOpenAsset]
        public static bool OnOpenWorld(int instanceID, int line)
        {
            var world = EditorUtility.InstanceIDToObject(instanceID) as WorldAsset;
            if (world == null || world.Scenes.Length <= 0)
                return false;

            EditorActionUtils.LoadScenes(world.Scenes, false);
            return true;
        }
    }
}