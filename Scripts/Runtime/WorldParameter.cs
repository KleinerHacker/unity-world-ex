using UnitySceneBase.Runtime.scene_system.scene_base.Scripts.Runtime.Components;
using UnitySceneBase.Runtime.scene_system.scene_base.Scripts.Runtime.Types;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime
{
    public static class WorldParameter
    {
        public static T Get<T>() where T : ParameterData => SceneParameterController.GetData<T>(WorldSystemSettings.Singleton.ParameterInitialData);
    }
}