using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelCompletedDialog : MonoBehaviour
{
    public static async UniTaskVoid WinDialog()
    {
        var dialogueGameObject = await Addressables.InstantiateAsync("LevelCompletedDialog.Win");
    }

    public static async UniTaskVoid LoseDialog()
    {
        var dialogueGameObject = await Addressables.InstantiateAsync("LevelCompletedLose");
    }
}
