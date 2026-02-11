using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 12f;
    public float gravity = 8f;
    public float groundCheckRadius = 0.15f;
    public LayerMask groundLayer;

    public bool canMove = true;

    private bool isGrounded;
    private Vector3 velocity;
    private Transform feet;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        feet = transform.Find("feet");
    }

    private void Update()
    {
        CheckIsGrounded();

        if (canMove)
        {
            Move();
        }

        ApplyGravity();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move);
    }

    private void CheckIsGrounded()
    {
        isGrounded = Physics.CheckSphere(feet.position, groundCheckRadius, groundLayer);
    }

    //Gravity for Character
    private void ApplyGravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y -= gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
