using UnitySceneBase.Runtime.scene_system.scene_base.Scripts.Runtime.Components;
using UnitySceneBase.Runtime.scene_system.scene_base.Scripts.Runtime.Types;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime
{
    public static class WorldParameter
    {
        public static bool HasData<T>() where T : ParameterData
        {
            return SceneParameterSystem.HasData<T>();
        }

        public static T GetData<T>() where T : ParameterData
        {
            return SceneParameterSystem.GetData<T>(WorldSystemSettings.Singleton.ParameterInitialData);
        }
    }
}