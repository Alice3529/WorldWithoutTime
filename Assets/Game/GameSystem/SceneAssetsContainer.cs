using UnityEngine;

namespace GameSystem
{
    public class SceneAssetsContainer : MonoBehaviour
    {
        [SerializeField] private AssetSceneReference startScene = default;
        [SerializeField] private AssetSceneReference progressScene = default;

        public AssetSceneReference StartScene => this.startScene;
        public AssetSceneReference ProgressScene => this.progressScene;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
