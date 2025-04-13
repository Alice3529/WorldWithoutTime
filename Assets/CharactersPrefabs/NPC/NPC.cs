using Dialogue;
using UnityEngine;

namespace Characters.NPC
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] private GameObject talkButton = default;
        [SerializeField] private DialogueItem dialogueItem = default;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerDialogue playerDialogue = collision.GetComponent<PlayerDialogue>();
                playerDialogue.SetDialogueToSpeak(this.dialogueItem);
                this.talkButton.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                this.talkButton.SetActive(false);
            }
        }
    }
}
