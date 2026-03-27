using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]    
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 movementVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get Movement Input

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Force 4-direction movement by prioritizing vertical input first.
        if (vertical != 0f)
        {
            horizontal = 0f;
        }

        // Apply Movement
        movementInput = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        // Apply Physics Update
        // Uses Unity 6+ physics API (linearVelocity).
        // If using older Unity versions, replace with: rb.velocity = movementInput * moveSpeed;
        rb.linearVelocity = movementInput * moveSpeed;
    }
}
