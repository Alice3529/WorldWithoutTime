using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.PlayerCharacter
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody = default;
        [SerializeField] private Animator animator = default;
        [SerializeField] private float speed = default;

        [SerializeField] private PlayerDialogue playerDialogue = default;

        private PlayerController playerController;
        private Vector2 movement = default;

        public void DisablePlayerController() => this.playerController.Disable();
   
        private void Awake()
        {
            this.playerController = new PlayerController();
            this.playerController.Enable();
            this.playerController.Controller.Attack.performed += OnAttack;
            this.playerDialogue.Initialize(this.playerController);
        }

        private void FixedUpdate()
        {
            this.movement = this.playerController.Controller.Movement.ReadValue<Vector2>();
            Vector2 positionToMove = this.movement * this.speed * Time.fixedDeltaTime;
            this.rigidBody.MovePosition(this.rigidBody.position + positionToMove);
            this.animator.SetBool("Walk", this.movement.magnitude > 0);
            this.FlipCharacter();
        }

        private void FlipCharacter()
        {
            if (this.movement.x > 0)
            { 
                this.transform.localScale = Vector3.one;
            }
            else if (this.movement.x < 0)
            {
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        private void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                this.animator.SetTrigger("Attack");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Gear")
            {
                Game.Instance.GearSystem.AddGear();
                collision.gameObject.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            this.playerController.Controller.Attack.performed -= OnAttack;
        }
    }
}
