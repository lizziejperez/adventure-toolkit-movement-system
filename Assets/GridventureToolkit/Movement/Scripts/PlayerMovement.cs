/*
 * PlayerMovement.cs
 * Gridventure Toolkit - Top-Down Movement System
 * Version: 1.0
 *
 * Author: Lizzie Perez
 * Description:
 * Handles 4-directional top-down movement using Rigidbody2D.
 * Designed for beginner-friendly projects and reusable systems.
 *
 * Compatibility:
 * - Unity Input Manager (legacy)
 * - Active Input Handling: Both
 *
 * Note:
 * Uses Input.GetAxisRaw(). Projects using the new Input System only
 * must enable "Both" in Player Settings or use a new input implementation.
 */

using UnityEngine;
#if ENABLE_INPUT_SYSTEM
    using UnityEngine.InputSystem;
#endif

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;


    [Header("Input Mode")]
        [SerializeField] private bool useNewInputSystem = false;

    #if ENABLE_INPUT_SYSTEM
        [Header("New Input System")]
        [SerializeField] private InputActionReference moveAction;
    #endif

    private Rigidbody2D rb;
    private Vector2 movementInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        #if ENABLE_INPUT_SYSTEM
            // Enable the assigned input action when this component is active.
            if (useNewInputSystem && moveAction != null)
            {
                moveAction.action.Enable();
            }
        #endif
    }

    private void OnDisable()
    {
        #if ENABLE_INPUT_SYSTEM
            // Disable the assigned input action when this component is inactive.
            if (useNewInputSystem && moveAction != null)
            {
                moveAction.action.Disable();
            }
        #endif
    }

    private void Update()
    {
        // Get Movement Input
        if (useNewInputSystem)
        {
            ReadNewInput();
        }
        else
        {
            ReadLegacyInput();
        }

        // Force 4-direction movement.
        // Horizontal is used only when it is stronger than vertical input.
        movementInput = ForceFourDirection(movementInput);
    }

    private void FixedUpdate()
    {
        // Apply Physics Update
        // Uses Unity 6+ physics API (linearVelocity).
        // If using older Unity versions, replace with: rb.velocity = movementInput * moveSpeed;
        rb.linearVelocity = movementInput * moveSpeed;
    }

    private void ReadLegacyInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementInput = new Vector2(horizontal, vertical).normalized;
    }

    private void ReadNewInput()
    {
        #if ENABLE_INPUT_SYSTEM
            // If no input action is assigned, stop movement safely.
            if (moveAction == null)
            {
                movementInput = Vector2.zero;
                return;
            }

            movementInput = moveAction.action.ReadValue<Vector2>().normalized;
        #else
            // If the new Input System is not available, stop movement safely.
            movementInput = Vector2.zero;
        #endif
    }

    private Vector2 ForceFourDirection(Vector2 input)
    {
        // Compare horizontal and vertical input strength.
        // If horizontal input is stronger, move only on the X axis.
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            return new Vector2(Mathf.Sign(input.x), 0f);
        }

        // If there is any vertical input, prioritize vertical movement.
        if (Mathf.Abs(input.y) > 0f)
        {
            return new Vector2(0f, Mathf.Sign(input.y));
        }

        // No input detected.
        return Vector2.zero;
    }

}