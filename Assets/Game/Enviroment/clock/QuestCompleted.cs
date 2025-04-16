using Characters.PlayerCharacter;
using LevelCompletedDialogs;
using UnityEngine;

namespace Quest
{
    public class QuestCompleted : MonoBehaviour
    {
        [SerializeField] private PlayerDialogue playerDialogue = default;
        [SerializeField] private Animator[] items = default;

        private void Start()
        {
            this.playerDialogue.dialogueStarted += AnimateItems;
            this.playerDialogue.dialogueCompleted += OnGameCompleted;
        }

        private void OnGameCompleted()
        {
            LevelCompletedDialog.WinDialog().Forget();
            Game.Instance.GearSystem.Reset();
            Destroy(this.playerDialogue.gameObject);
        }

        private void AnimateItems()
        {
            foreach (Animator item in this.items)
            {
                item.GetComponent<Animator>().enabled = true;
            }
        }
    }
}
