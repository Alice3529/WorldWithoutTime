using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace NavigationSystem
{
    public class Navigation
    {
        public Navigation() { }

        public async UniTaskVoid LoadScene(AssetSceneReference sceneToLoad, float loadDuaration = 0.5f)
        {
            await Resources.UnloadUnusedAssets();
            var task = sceneToLoad.LoadSceneAsync(activateOnLoad: false);
            SceneInstance sceneInstanse = await task;
            await UniTask.Delay(TimeSpan.FromSeconds(loadDuaration));
            await sceneInstanse.ActivateAsync();
        }
    }
}
