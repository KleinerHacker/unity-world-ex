using System;
using UnitySceneBase.Runtime.scene_system.scene_base.Scripts.Runtime.Types;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Components;

namespace UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime
{
    public static class WorldSystem
    {
        public static void Load(string identifier, ParameterData parameterData = null, bool overwrite = true) => 
            WorldController.Singleton.Load(identifier, parameterData, overwrite);

        public static void Load(string identifier, bool doNotUnload, ParameterData parameterData = null, bool overwrite = true) => 
            WorldController.Singleton.Load(identifier, doNotUnload, parameterData, overwrite);

        public static void Load(string identifier, Action onFinished, ParameterData parameterData = null, bool overwrite = true) => 
            WorldController.Singleton.Load(identifier, onFinished, parameterData, overwrite);

        public static void Load(string identifier, bool doNotUnload, Action onFinished, ParameterData parameterData = null, bool overwrite = true) => 
            WorldController.Singleton.Load(identifier, doNotUnload, onFinished, parameterData, overwrite);
    }
}