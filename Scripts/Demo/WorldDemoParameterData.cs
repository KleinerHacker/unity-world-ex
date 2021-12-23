using UnityEngine;
using UnitySceneBase.Runtime.scene_system.scene_base.Scripts.Runtime.Types;

namespace UnityWorldEx.Demo.scene_system.world_ex.Scripts.Demo
{
    [ParameterInitialDataType(typeof(WorldDemoInitialData))]
    public sealed class WorldDemoParameterData : ParameterData
    {
        public string Text { get; set; }

        public override void InitializeData(ScriptableObject initData)
        {
            var data = (WorldDemoInitialData)initData;
            Text = data.Text;
        }
    }
}