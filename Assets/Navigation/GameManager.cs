using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SceneAssetsContainer SceneAsset;

    private void Start()
    {
        Game game = new Game();
        Navigation navigation = Game.Instance.Navigation;
        navigation.SetProgressScene(this.SceneAsset.ProgressScene);
        navigation.LoadScene(this.SceneAsset.StartScene).Forget();
    }
}
