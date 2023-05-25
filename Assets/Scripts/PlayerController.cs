using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private bool moving;
    
    private float moveHorizontal, moveVertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!UIManager.Instance.IsPanelOpen())
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        else
        {
            moveHorizontal = 0f;
            moveVertical = 0f;
        }

        movement = new Vector2(moveHorizontal, moveVertical);

        UpdateAnimator(moveHorizontal, moveVertical);
        UpdateMovementState(moveHorizontal, moveVertical);

        // Check for key inputs
        if (Input.GetKeyDown(KeyCode.B))
        {
            UIManager.Instance.ShopPanel.Show(); // Open the shop in the UIManager
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            UIManager.Instance.InventoryPanel.Show(); // Open the inventory in the UIManager
        }
    }

    private void FixedUpdate()
    {
        //if (UIManager.Instance.IsPanelOpen())
        //    return; // Ignore inputs if there is an open panel in the UIManager

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

    private void Stop()
    {

    }
}
