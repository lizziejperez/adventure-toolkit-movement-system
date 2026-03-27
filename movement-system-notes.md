# Player Movement System — Notes & Concepts

## Overview

This system implements a simple **top-down 2D movement controller** in Unity using C#.
It uses Rigidbody2D physics to move a player smoothly in four directions.
This system supports both Unity's legacy Input Manager and Unity's new Input System.

## Table of Contents

* [Overview](#overview)
* [Key Concepts Learned](#key-concepts-learned)
  * [1. RequireComponent](#1-requirecomponent)
  * [2. SerializeField](#2-serializefield)
  * [3. Awake vs Update vs FixedUpdate](#3-awake-vs-update-vs-fixedupdate)
  * [4. Input.GetAxisRaw](#4-inputgetaxisraw)
  * [5. 4-Direction Movement Logic](#5-4-direction-movement-logic)
  * [6. Vector2 and Direction](#6-vector2-and-direction)
  * [7. Normalization](#7-normalization)
  * [8. Rigidbody2D Movement](#8-rigidbody2d-movement)
  * [9. Unity Physics API Differences](#9-unity-physics-api-differences)
  * [10. Separation of Input and Movement](#10-separation-of-input-and-movement)
  * [11. Conditional Compilation (#if)](#11-conditional-compilation-if)
  * [12. Input System Compatibility](#12-input-system-compatibility)
* [System Design Takeaways](#system-design-takeaways)
* [Summary](#summary)
* [Future Improvements Ideas](#future-improvements-ideas)

## Key Concepts Learned

### 1. RequireComponent

```csharp
[RequireComponent(typeof(Rigidbody2D))]
```

Ensures that any GameObject using this script **must have a Rigidbody2D attached**.

Why this matters:

* Prevents runtime errors
* Enforces correct setup automatically
* Makes the script safer and easier to reuse

### 2. SerializeField

```csharp
[SerializeField] private float moveSpeed = 5f;
```

Allows a **private variable** to be:

* visible in the Unity Inspector
* editable without exposing it publicly

Why this matters:

* keeps encapsulation (good coding practice)
* allows designers/developers to tweak values easily
* improves usability of reusable systems

### 3. Awake vs Update vs FixedUpdate

`Awake()`:

* called once when the object is initialized
* used to cache components (GetComponent)

`Update()`:

* called every frame
* used for input handling

`FixedUpdate()`:

* called at fixed time intervals
* used for physics updates

Why this separation matters:

* input should be frame-based
* physics should be time-consistent
* prevents jitter and inconsistent movement

### 4. Input.GetAxisRaw

```csharp
Input.GetAxisRaw("Horizontal")
Input.GetAxisRaw("Vertical")
```

Returns:

* -1 (negative direction)
* 0 (no input)
* 1 (positive direction)

Key difference from GetAxis:

* no smoothing
* immediate response

Why this matters:

* better for precise, responsive controls
* ideal for grid or arcade-style movement

### 5. 4-Direction Movement Logic

```csharp
private Vector2 ForceFourDirection(Vector2 input)
{
    if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
    {
        return new Vector2(Mathf.Sign(input.x), 0f);
    }

    if (Mathf.Abs(input.y) > 0f)
    {
        return new Vector2(0f, Mathf.Sign(input.y));
    }

    return Vector2.zero;
}
```

This implementation compares the strength of horizontal and vertical input and keeps only the dominant direction.

Key ideas:

* diagonal input is resolved into a single direction
* movement is restricted to up, down, left, or right
* `Mathf.Sign` converts input into discrete directions (-1, 0, or 1)

Why this matters:

* prevents diagonal movement
* creates consistent grid-like control
* mimics classic top-down adventure games
* provides more flexible and predictable control compared to simple axis cancellation

This approach also allows control over direction priority. In this implementation, vertical movement is prioritized when both axes have equal input.

### 6. Vector2 and Direction

```csharp
new Vector2(horizontal, vertical)
```

Represents movement direction:

* (1, 0) → right
* (0, 1) → up
* (-1, 0) → left
* (0, -1) → down

### 7. Normalization

```csharp
movementInput = new Vector2(horizontal, vertical).normalized;
```

Normalization:

* keeps direction the same
* sets vector length (magnitude) to 1

Why this matters:

* prevents faster diagonal movement
* ensures consistent speed in all directions
* future-proofs the system if diagonal movement is added later

### 8. Rigidbody2D Movement

```csharp
rb.linearVelocity = movementInput * moveSpeed;
```

This applies movement using physics.

Key idea:

* direction (movementInput) × speed = velocity

### 9. Unity Physics API Differences

Modern Unity (Unity 6+):

* `rb.linearVelocity`

Older Unity:

* `rb.velocity`

Why this matters:

* APIs evolve over time
* writing adaptable code increases compatibility
* important when sharing or selling templates

### 10. Separation of Input and Movement

Input is handled in `Update()`
Physics is applied in `FixedUpdate()`

Flow:

1. Read input → Update
2. Store direction → movementInput
3. Apply velocity → FixedUpdate

Why this matters:

* prevents inconsistent movement
* keeps logic clean and predictable

### 11. Conditional Compilation (#if)

```csharp
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
```

Conditional compilation allows code to be included or excluded depending on project settings.

In this system, it is used to support both:

* Unity's legacy Input Manager
* Unity's new Input System

Example:

```csharp
#if ENABLE_INPUT_SYSTEM
movementInput = moveAction.action.ReadValue<Vector2>();
#else
movementInput = Vector2.zero;
#endif
```

Why this matters:

* prevents compile errors if the new Input System is not installed
* allows one script to support multiple input systems
* makes the code more flexible and reusable across projects

This is especially useful when building tools or assets intended for different Unity setups.

### 12. Input System Compatibility

This system supports both:

* Unity's legacy Input Manager (Input.GetAxisRaw)
* Unity's new Input System (Input Actions)

A toggle in the PlayerMovement script allows switching between them.

Why this matters:

* improves compatibility across Unity versions
* supports modern workflows
* makes the system more flexible and reusable

## System Design Takeaways

* Keep systems **simple and focused**
* Prioritize **readability over complexity**
* Use Unity’s lifecycle methods correctly
* Write code that is:

  * reusable
  * beginner-friendly
  * easy to modify

## Summary

This movement system demonstrates:

* clean Unity architecture
* proper input + physics separation
* reusable component design
* beginner-friendly implementation

It serves as a strong foundation for:

* 2D adventure games
* RPG-style movement
* reusable Unity templates

## Future Improvements Ideas

* Diagonal movement toggle
* Animation integration
* Sprint mechanic
* Input System package support
* Acceleration / deceleration smoothing