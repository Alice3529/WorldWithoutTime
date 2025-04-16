using NavigationSystem;
using UnityEngine;

namespace GameSystem
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SceneAssetsContainer SceneAsset = default;

        private void Start()
        {
            Game game = new Game();
            Navigation navigation = game.Navigation;
            navigation.LoadScene(this.SceneAsset.StartScene).Forget();
        }
    }
}
