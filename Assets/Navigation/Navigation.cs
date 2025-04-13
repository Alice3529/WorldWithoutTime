using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;

public class Navigation : MonoBehaviour
{
    private AssetSceneReference progressScene = default;

    public Navigation() { }
    
    public void SetProgressScene(AssetSceneReference progressScene)
    {
        this.progressScene = progressScene;
    }

    public async UniTaskVoid LoadScene(AssetSceneReference sceneToLoad, float loadDuaration = 0.5f)
    {
      // await Addressables.LoadSceneAsync(this.progressScene);
       await Resources.UnloadUnusedAssets();
       var task = sceneToLoad.LoadSceneAsync(activateOnLoad: false);
       SceneInstance sceneInstanse = await task;
       await UniTask.Delay(TimeSpan.FromSeconds(loadDuaration));
       await sceneInstanse.ActivateAsync();
    }
}
