using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Dialogs
{
    public class LevelCompletedDialog : MonoBehaviour
    {
        public static async UniTaskVoid WinDialog()
        {
            var dialogueGameObject = await Addressables.InstantiateAsync("LevelCompletedWin");
        }

        public static async UniTaskVoid LoseDialog()
        {
            var dialogueGameObject = await Addressables.InstantiateAsync("LevelCompletedLose");
        }
    }
}
