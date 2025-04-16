using UnityEngine;
using Dialogue;
using Characters.PlayerCharacter;

namespace Characters.NpcCharacter
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] private GameObject talkButton = default;
        public DialogueItem dialogueItem = default;

        public void EnableTalkButton(bool active) => this.talkButton.SetActive(active);
       
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerDialogue playerDialogue = collision.GetComponent<PlayerDialogue>();
                playerDialogue.SetCharacterToSpeak(this);
                this.talkButton.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerDialogue playerDialogue = collision.GetComponent<PlayerDialogue>();
                playerDialogue.SetCharacterToSpeak(null);
                this.talkButton.SetActive(false);
            }
        }
    }
}
