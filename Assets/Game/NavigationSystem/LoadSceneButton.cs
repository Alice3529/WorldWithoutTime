using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace NavigationSystem
{
    [RequireComponent(typeof(Button))]
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField] private AssetSceneReference sceneAssetReference = default;

        void Start()
        {
            Button button = GetComponent<Button>();

            button.OnClickAsObservable()
                .Subscribe(_ => Game.Instance.Navigation.LoadScene(this.sceneAssetReference).Forget())
                .AddTo(this);
        }
    }
}
