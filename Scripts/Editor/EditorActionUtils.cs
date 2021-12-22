using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Editor.scene_system.world_ex.Scripts.Editor
{
    public static class EditorActionUtils
    {
        public static void LoadScenes(SceneData[] scenes, bool loadRuntime)
        {
            try
            {
                LoadScene(scenes[0], 0f, false, loadRuntime);
                if (scenes.Length > 1)
                {
                    for (var i = 0; i < scenes.Length; i++)
                    {
                        LoadScene(scenes[i], (float) i / scenes.Length, true, loadRuntime);
                    }
                }

                var activeScene = scenes.FirstOrDefault(x => x.ActiveScene)?.Scene;
                if (!string.IsNullOrEmpty(activeScene))
                {
                    EditorSceneManager.SetActiveScene(EditorSceneManager.GetSceneByPath(activeScene));
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
        }
        
        private static void LoadScene(SceneData sceneData, float progress, bool additive, bool loadRuntime)
        {
            EditorUtility.DisplayProgressBar("Open World", "Load scene " + sceneData.Scene, progress);
            var scene = EditorSceneManager.OpenScene(sceneData.Scene, additive ? OpenSceneMode.Additive : OpenSceneMode.Single);
            if (loadRuntime)
            {
                if (sceneData.LoadingBehavior == SceneLoadingBehavior.OnlyInEditor)
                {
                    EditorSceneManager.CloseScene(scene, false);
                }
            }
            else
            {
                if (sceneData.LoadingBehavior == SceneLoadingBehavior.OnlyAtRuntime)
                {
                    EditorSceneManager.CloseScene(scene, false);
                }
            }
        }
    }
}