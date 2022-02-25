using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityExtension.Runtime.extension.Scripts.Runtime.Components.Singleton.Attributes;
using UnitySceneBase.Runtime.scene_system.scene_base.Scripts.Runtime.Assets;
using UnitySceneBase.Runtime.scene_system.scene_base.Scripts.Runtime.Components;
using UnitySceneBase.Runtime.scene_system.scene_base.Scripts.Runtime.Types;
using UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Runtime.scene_system.world_ex.Scripts.Runtime.Components
{
    public sealed class WorldController : SceneControllerBase<WorldController, WorldItem>
    {
        #region Static Area

        [SingletonCondition]
        public static bool IsSingletonAlive() => WorldSystemSettings.Singleton.UseSystem;

        [SingletonInitializer]
        public static void Initialize(WorldController instance)
        {
            Debug.Log("Loading world system");
            LoadSceneSystemBasics(WorldSystemSettings.Singleton.BlendingSystem, WorldSystemSettings.Singleton.AdditionalGameObjects, 
                WorldSystemSettings.Singleton.CreateEventSystem,
                eventSystem =>
                {
                    eventSystem.sendNavigationEvents = WorldSystemSettings.Singleton.ESUseNavigation;
                    eventSystem.firstSelectedGameObject = WorldSystemSettings.Singleton.ESFirstSelection;
                    eventSystem.pixelDragThreshold = WorldSystemSettings.Singleton.ESDragThreshold;
                },
                inputModule =>
                {
                    inputModule.moveRepeatDelay = WorldSystemSettings.Singleton.ESMoveRepeatDelay;
                    inputModule.moveRepeatRate = WorldSystemSettings.Singleton.ESMoveRepeatRate;
                    inputModule.deselectOnBackgroundClick = WorldSystemSettings.Singleton.ESDeselectOnBackground;
                    inputModule.pointerBehavior = WorldSystemSettings.Singleton.ESPointerBehavior;
                    if (WorldSystemSettings.Singleton.ESActionAsset != null)
                    {
                        inputModule.actionsAsset = WorldSystemSettings.Singleton.ESActionAsset;
                    }

                    inputModule.xrTrackingOrigin = WorldSystemSettings.Singleton.ESXROrigin;
                });
            
            var worldItem = WorldSystemSettings.Singleton.Items
                .FirstOrDefault(x => x.World.Scenes.Any(y => SceneManager.GetActiveScene().path == y.Scene));
            instance.RaiseSceneEvent(RuntimeOnSwitchSceneType.LoadScenes, worldItem?.Identifier, new[] { SceneManager.GetActiveScene().path });
        }

        #endregion
        
        #region Properties

        protected override bool UseBlendCallbacks => WorldSystemSettings.Singleton.UseBlendCallbacks;
        protected override bool UseSwitchCallbacks => WorldSystemSettings.Singleton.UseSwitchCallbacks;
        protected override SceneBlendState StartupBlendState => WorldSystemSettings.Singleton.StartupBlendState;

        #endregion

        public override void Load(string identifier, bool doNotUnload, Action onFinished, ParameterData parameterData = null, bool overwrite = true) => 
            Load(identifier, doNotUnload, onFinished, parameterData, overwrite, WorldSystemSettings.Singleton.ParameterInitialData);

        protected override void RaiseBlendEvent(RuntimeOnBlendSceneType type, string identifier, Action asyncAction)
        {
            base.RaiseBlendEvent(type, identifier, asyncAction);
            
            if (type == RuntimeOnBlendSceneType.PreHideBlend)
            {
                var worldItem = FindSceneItem(identifier);
                if (worldItem == null)
                    throw new InvalidOperationException("Unable to find world " + identifier);

                if (worldItem.ActiveScene != null)
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByPath(worldItem.ActiveScene));
                }
            }
        }

        protected override string[] RaiseSceneEvent(RuntimeOnSwitchSceneType type, string identifier, string[] scenes)
        {
            var result = base.RaiseSceneEvent(type, identifier, scenes);
            if (type == RuntimeOnSwitchSceneType.UnloadScenes)
            {
                var scenesNeverUnload = WorldSystemSettings.Singleton.Items
                    .Where(x => x.NeverUnload)
                    .SelectMany(x => x.Scenes)
                    .ToArray();
                
                result = result.Where(x => !scenesNeverUnload.Contains(x)).ToArray();
            }

            return result;
        }

        protected override WorldItem FindSceneItem(string identifier) => WorldSystemSettings.Singleton.Items.FirstOrDefault(x => x.Identifier == identifier);
        
        protected override string GetAllowedParameterDataType(string identifier)
        {
            var sceneItem = WorldSystemSettings.Singleton.Items.FirstOrDefault(x => x.Identifier == identifier);
            if (sceneItem == null)
                throw new ArgumentException("Identifier unknown: " + identifier);

            return sceneItem.ParameterDataType;
        }

        protected override bool IsAllowNullParameterData(string identifier)
        {
            var sceneItem = WorldSystemSettings.Singleton.Items.FirstOrDefault(x => x.Identifier == identifier);
            if (sceneItem == null)
                throw new ArgumentException("Identifier unknown: " + identifier);

            return sceneItem.ParameterDataAllowNull;
        }
    }
}