using Characters.NpcCharacter;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.PlayerCharacter
{ 
   public class PlayerDialogue : MonoBehaviour
    {
        [SerializeField] private NPC npc = default;
        private PlayerController playerController = default;

        public event Action dialogueStarted = default;
        public event Action dialogueCompleted = default;

        public void SetCharacterToSpeak(NPC npc) => this.npc = npc;

        public void Initialize(PlayerController playerController)
        {
            this.playerController = playerController;
            this.playerController.Controller.Talk.performed += OnTalk;
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
            if (this.npc != null)
            {
                this.StartDialogue();
                await Game.Instance.DialogueSystem.CreateDialogue(this.npc.dialogueItem);
                this.EndDialogue();
            }
        }

        private void StartDialogue()
        {
            this.npc.EnableTalkButton(false);
            this.playerController.Disable();
            this.dialogueStarted?.Invoke();
        }

        private void EndDialogue()
        {
            this.npc.EnableTalkButton(true);
            this.playerController.Enable();
            this.dialogueCompleted?.Invoke();
        }

        private void OnDestroy()
        {
            this.playerController.Controller.Talk.performed -= OnTalk;
        }
    }
}
