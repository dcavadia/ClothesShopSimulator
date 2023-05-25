using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private bool moving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical);

        UpdateAnimator(moveHorizontal, moveVertical);
        UpdateMovementState(moveHorizontal, moveVertical);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void UpdateAnimator(float moveHorizontal, float moveVertical)
    {
        animator.SetFloat("Horizontal", moveHorizontal);
        animator.SetFloat("Vertical", moveVertical);
    }

    private void UpdateMovementState(float moveHorizontal, float moveVertical)
    {
        moving = moveHorizontal != 0 || moveVertical != 0;
        animator.SetBool("Moving", moving);

        if (moving)
        {
            animator.SetFloat("LastHorizontal", moveHorizontal);
            animator.SetFloat("LastVertical", moveVertical);
        }
    }

    private void Move()
    {
        rb.velocity = movement * movementSpeed;
    }
}
