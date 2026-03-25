# Player Movement System — Notes & Concepts

## Overview

This system implements a simple **top-down 2D movement controller** in Unity using C#.
It uses Unity’s input system and Rigidbody2D physics to move a player smoothly in four directions.

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
if (horizontal != 0f)
{
    vertical = 0f;
}
```

This forces movement to:

* left/right OR up/down
* never both at the same time

Why this matters:

* prevents diagonal movement
* mimics classic top-down games
* simplifies control behavior

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

## System Design Takeaways

* Keep systems **simple and focused**
* Prioritize **readability over complexity**
* Use Unity’s lifecycle methods correctly
* Write code that is:

  * reusable
  * beginner-friendly
  * easy to modify

## Future Improvements Ideas

* Diagonal movement toggle
* Animation integration
* Sprint mechanic
* Input System package support
* Acceleration / deceleration smoothing

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
