using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LevelCompletedDialogs
{
    public class LevelCompletedDialog : MonoBehaviour
    {
        public static async UniTaskVoid WinDialog()
            => await Addressables.InstantiateAsync("LevelCompletedWin");

        public static async UniTaskVoid LoseDialog() 
            => await Addressables.InstantiateAsync("LevelCompletedLose");
    }
}
