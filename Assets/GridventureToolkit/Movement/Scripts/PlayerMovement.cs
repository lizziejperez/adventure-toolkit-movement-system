/*
 * PlayerMovement.cs
 * Gridventure Toolkit - 2D Movement System (Top-Down)
 * Author: Lizzie Perez
 * Version: 2.0
 */
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles top-down 2D movement using Unity's New Input System.
/// Supports 4-direction movement by default with optional diagonal movement.
/// Applies velocity through Rigidbody2D for physics-based movement.
/// Designed for beginner-friendly projects and reusable systems.
/// </summary>
/// <remarks>
/// Requires a Rigidbody2D and PlayerInput component.
/// Expects a "Move" action (Vector2) in the assigned Input Actions asset.
/// </remarks>
[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private bool allowDiagonalMovement = false;

    [Header("Debug Settings")]
    [SerializeField] private bool inDebugMode = false;

    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private Vector2 moveInput;

    // Initialization

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }

    private void OnEnable()
    {
        moveAction.started += OnMoveStarted;
        moveAction.performed += OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;
    }

    // Helper methods for Player Input

    private void OnMoveStarted(InputAction.CallbackContext callbackContext)
    {
        moveInput = callbackContext.ReadValue<Vector2>();

        if (inDebugMode)
        {
            Debug.Log("OnMoveStarted called!\nMove Input: " + moveInput);
        }        
    }

    private void OnMovePerformed(InputAction.CallbackContext callbackContext) 
    {
        moveInput = callbackContext.ReadValue<Vector2>();

        if (inDebugMode)
        {
            Debug.Log("OnMovePerformed called!\nCallback Context: " + moveInput);
        }
    }

    private void OnMoveCanceled(InputAction.CallbackContext callbackContext)
    {
        moveInput = callbackContext.ReadValue<Vector2>();

        if (inDebugMode)
        {
            Debug.Log("OnMoveCanceled called!\nCallback Context: " + moveInput);
        }
    }

    // Used for Physics handling
    private void FixedUpdate()
    {
        Vector2 direction = moveInput;

        if (!allowDiagonalMovement)
        {
            // Fix direction for 4-direction movement
            float x = Mathf.Abs(direction.x);
            float y = Mathf.Abs(direction.y);
            if (x > y)
            {
                direction.y = 0f;
            }
            else
            {
                direction.x = 0f;
            }
        }        

        // Apply movement using Rigidbody2D linear velocity     
        rb.linearVelocity = speed * direction;
    }

    // Decommisioning
    private void OnDisable()
    {
        moveAction.started -= OnMoveStarted;
        moveAction.performed -= OnMovePerformed;
        moveAction.canceled -= OnMoveCanceled;
    }
}
