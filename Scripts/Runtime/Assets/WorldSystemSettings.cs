using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnitySceneBase.Runtime.scene_system.scene_base.Scripts.Runtime.Assets;
#if WORLD_SCENE_ONLY_RUNTIME || !UNITY_EDITOR
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Utils.Extensions;
#endif

namespace UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets
{
    public sealed class WorldSystemSettings : SceneSystemSettingsBase<WorldItem, WorldSystemSettings>
    {
        #region Static Area

        private const string FileName = "world-system.asset";

        public static WorldSystemSettings Singleton => GetSingleton("World System", FileName);

#if UNITY_EDITOR
        public static SerializedObject SerializedSingleton => GetSerializedSingleton("World System", FileName);
#endif

        #endregion
    }

    [Serializable]
    public sealed class WorldItem : SceneItemBase
    {
        #region Inspector Data

        [SerializeField]
        private WorldAsset world;

        #endregion

        #region Properties

        public WorldAsset World => world;

        public override string[] Scenes =>
            world.Scenes
#if WORLD_SCENE_ONLY_RUNTIME || !UNITY_EDITOR
                .FilterRuntimeScenes()
#endif
                .Select(x => x.Scene)
                .ToArray();

        public string ActiveScene => world.Scenes.FirstOrDefault(x => x.ActiveScene)?.Scene;

        #endregion
    }
}