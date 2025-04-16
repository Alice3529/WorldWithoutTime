using UnityEngine;

namespace Portal
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private AssetSceneReference level = default;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Game.Instance.Navigation.LoadScene(this.level).Forget();
            }
        }
    }
}
