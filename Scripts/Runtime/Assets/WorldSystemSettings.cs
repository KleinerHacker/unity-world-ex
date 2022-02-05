using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnitySceneBase.Runtime.scene_system.scene_base.Scripts.Runtime.Assets;
#if !UNITY_EDITOR
using UnityAssetLoader.Runtime.asset_loader.Scripts.Runtime.Loader;
#endif

namespace UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets
{
    public sealed class WorldSystemSettings : SceneSystemSettingsBase<WorldItem>
    {
        #region Static Area

#if UNITY_EDITOR
        private const string Path = "Assets/Resources/world-system.asset";
#endif

        public static WorldSystemSettings Singleton
        {
            get
            {
#if UNITY_EDITOR
                var settings = AssetDatabase.LoadAssetAtPath<WorldSystemSettings>(Path);
                if (settings == null)
                {
                    Debug.Log("Unable to find game settings, create new");

                    settings = new WorldSystemSettings();
                    AssetDatabase.CreateAsset(settings, Path);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }

                return settings;
#else
                return AssetResourcesLoader.Instance.GetAsset<WorldSystemSettings>();
#endif
            }
        }

#if UNITY_EDITOR
        public static SerializedObject SerializedSingleton => new SerializedObject(Singleton);
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

        public override string[] Scenes => world.Scenes.Select(x => x.Scene).ToArray();

        public string ActiveScene => world.Scenes.FirstOrDefault(x => x.ActiveScene)?.Scene;

        #endregion
    }
}