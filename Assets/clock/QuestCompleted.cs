using Characters.NPC;
using UnityEngine;

public class QuestCompleted : MonoBehaviour
{
    [SerializeField] private NPC npc = default;
    [SerializeField] private GameObject[] items = default;

    private void Start()
    {
        this.npc.dialogueStarted += AnimateItems;
    }

    private void AnimateItems()
    {
        foreach (GameObject item in this.items)
        {
            item.GetComponent<Animator>().enabled = true;
        }
    }
}
