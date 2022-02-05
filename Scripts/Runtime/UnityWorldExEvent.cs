using UnityAssetLoader.Runtime.asset_loader.Scripts.Runtime.Loader;
using UnityEngine;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime
{
    public static class UnityWorldExEvent
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        public static void Initialize()
        {
            Debug.Log("Load world settings");
            AssetResourcesLoader.Instance.LoadAssets<WorldSystemSettings>("");
        }
    }
}