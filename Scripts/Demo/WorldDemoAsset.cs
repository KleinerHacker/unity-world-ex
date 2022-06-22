#if DEMO
using UnityEngine;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Extras;

namespace UnityWorldEx.Demo.scene_system.world_ex.Scripts.Demo
{
    [CreateAssetMenu(menuName = "DEMO/World Demo Asset")]
    public sealed class WorldDemoAsset : ScriptableObject
    {
        [WorldSystemSelector]
        [SerializeField]
        private string world;
    }
}
#endif