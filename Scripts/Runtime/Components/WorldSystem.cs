using System;
using System.Linq;
using UnityEditorEx.Runtime.editor_ex.Scripts._00_Runtime.Types;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnitySceneEx.Runtime.scene_ex.Scripts.Runtime.Components;
using UnityWorldEx.Runtime.world_ex.Scripts.Runtime.Assets;

namespace UnityWorldEx.Runtime.world_ex.Scripts.Runtime.Components
{
    public abstract class WorldSystem<TWorld, T> : SceneSystem<TWorld, T> where TWorld : WorldData<T> where T : Enum
    {
        protected override void OnLoadingFinished(T newState, TWorld world, object data)
        {
            var scene = world?.World?.Scenes.FirstOrDefault(x => x.ActiveScene);
            if (scene == null)
                return;

            SceneManager.SetActiveScene(SceneManager.GetSceneByPath(scene.Scene));
        }
    }

    [Serializable]
    public abstract class WorldData<T> : SceneData<T>, IIdentifiedObject<T> where T : Enum
    {
        #region Inspector Data

        [SerializeField]
        private WorldAsset world;

        #endregion

        #region Properties

        public WorldAsset World => world;

        public override string[] Scenes => base.Scenes.Concat(
            world.Scenes
                .Where(x => x.LoadingBehavior != (Application.isEditor ? SceneLoadingBehavior.OnlyAtRuntime : SceneLoadingBehavior.OnlyInEditor))
                .Select(x => x.Scene)
        ).ToArray();

        #endregion

        protected WorldData(T identifier) : base(identifier)
        {
        }
    }
}