#if DEMO
using UnityEngine;
#endif

namespace UnityWorldEx.Demo.scene_system.world_ex.Scripts.Demo
{
#if DEMO
    public class WorldDemoInitialData : ScriptableObject
    {
        [SerializeField]
        private string text;

        public string Text => text;
    }
#endif
}