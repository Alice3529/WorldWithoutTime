using Characters.Player;
using Dialogs;
using UnityEngine;

public class QuestCompleted : MonoBehaviour
{
    [SerializeField] private PlayerDialogue playerDialogue = default;
    [SerializeField] private GameObject[] items = default;

    private void Start()
    {
        this.playerDialogue.dialogueStarted += AnimateItems;
        this.playerDialogue.dialogueCompleted += OnGameCompleted;
    }

    private void OnGameCompleted()
    {
        LevelCompletedDialog.WinDialog().Forget();
    }

    private void AnimateItems()
    {
        foreach (GameObject item in this.items)
        {
            item.GetComponent<Animator>().enabled = true;
        }
    }
}
