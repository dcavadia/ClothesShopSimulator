using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool moving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleMovementInput();
        HandleKeyInputs();
    }

    private void HandleMovementInput()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (!UIManager.Instance.IsPanelOpen())
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        UpdateAnimator(moveHorizontal, moveVertical);
        UpdateMovementState(moveHorizontal, moveVertical);

        rb.velocity = movement * movementSpeed;
    }

    private void HandleKeyInputs()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UIManager.Instance.InventoryPanel.Show();
        }
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
}
