using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput = default;
    [SerializeField] private Rigidbody2D rigidbody = default;
    [SerializeField] private Animator animator = default;
    [SerializeField] private float speed = default;

    private PlayerController playerController;

    Vector2 movement;

    private void Awake()
    {
        playerController = new PlayerController();
        playerController.Enable();
        playerController.Attack.Attack.performed += OnAttack;
    }

    private void FixedUpdate()
    {
        movement = playerController.Controller.Movement.ReadValue<Vector2>();
        rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
        animator.SetBool("isWalking", movement.magnitude > 0);
        this.FlipCharacter(movement.x);
    }

    private void FlipCharacter(float horizontalMovement)
    {
        if (horizontalMovement > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalMovement < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            this.animator.SetTrigger("attack");
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
        playerController.Attack.Attack.performed -= OnAttack;
    }

}
