using UnityEngine;

namespace UnityWorldEx.Demo.scene_system.world_ex.Scripts.Demo
{
    public class WorldDemoInitialData : ScriptableObject
    {
        [SerializeField]
        private string text;

        public string Text => text;
    }
}