using Cysharp.Threading.Tasks;
using Dialogue;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDialogue : MonoBehaviour
{
    [SerializeField] private DialogueItem dialogueToSpeak = default;
    private PlayerController playerController = default;

    private bool talking = false;

    public event Action dialogueStarted = default;
    public event Action dialogueCompleted= default;

    private void Awake()
    {
        this.playerController = new PlayerController();
        this.playerController.Enable();
        this.playerController.Talk.Talk.performed += OnTalk;
    }

    private void OnTalk(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
            this.Talk().Forget();
        }
    }

    private async UniTaskVoid Talk()
    {
        if (this.dialogueToSpeak != null && this.talking == false)
        {
            this.dialogueStarted?.Invoke();
            this.talking = true;
            await Game.Instance.DialogueSystem.CreateDialogue(this.dialogueToSpeak);
            this.talking = false;
            this.dialogueCompleted?.Invoke();
        }
    }

    public void SetDialogueToSpeak(DialogueItem dialogue)
    {
        this.dialogueToSpeak = dialogue;
    }
}
