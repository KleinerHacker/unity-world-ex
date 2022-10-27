using System.Collections.Generic;
using System.Linq;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Utils.Extensions
{
    public static class WorldSceneExtensions
    {
        public static IEnumerable<SceneData> FilterRuntimeScenes(this IEnumerable<SceneData> scenes)
        {
            return scenes
                .Where(x => x.LoadingBehavior != SceneLoadingBehavior.OnlyInEditor);
        } 
    }
}