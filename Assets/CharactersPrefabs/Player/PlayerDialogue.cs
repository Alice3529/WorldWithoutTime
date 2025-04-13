using Dialogue;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDialogue : MonoBehaviour
{
    [SerializeField] private DialogueItem dialogueToSpeak = default;
    private PlayerController playerController = default;

    private void Awake()
    {
        this.playerController = new PlayerController();
        this.playerController.Enable();
        this.playerController.Talk.Talk.performed += OnTalk;
    }

    private void OnTalk(InputAction.CallbackContext contex)
    {
        if (contex.performed && this.dialogueToSpeak != null)
        {
            Game.Instance.DialogueSystem.CreateDialogue(this.dialogueToSpeak).Forget();
        }
    }

    public void SetDialogueToSpeak(DialogueItem dialogue)
    {
        this.dialogueToSpeak = dialogue;
    }
}
