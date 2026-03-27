# Adventure Toolkit: Top-Down Movement System (Unity C#)

A reusable, adventure game–inspired 2D movement system with support for both Unity input systems — designed for clarity, flexibility, and easy integration.

Built in Unity with C#, this beginner-friendly system provides clean, responsive 4-direction movement and a ready-to-use demo for quick setup and testing.

## Features

* 4-directional movement (up, down, left, right)
* Smooth and responsive controls
* Adjustable movement speed via Inspector
* Simple, readable C# implementation
* Ready-to-use demo scene for testing and integration
* Supports both Unity Input Manager and the new Input System (toggleable)

## Who It’s For

Perfect for:
* Beginners learning game development
* Building top-down adventure games
* Expanding into more complex systems

Use this as a foundation for your own projects.

## Controls

* W / A / S / D — Move
* Arrow Keys — Move

<!-- ## Preview -->

## How to Use

1. Open the project in Unity (tested with Unity 6 LTS)
2. Open the demo scene: `Assets/AdventureToolkit/Movement/Scenes/DemoScene`
3. Press Play to test movement
4. Adjust movement speed in the Player Inspector

### Input System Setup (Optional)

This project supports both Unity's legacy Input Manager and the new Input System.

To use the new Input System:

1. Ensure "Active Input Handling" is set to **Both** in: `Edit → Project Settings → Player`
2. Open the Player prefab
3. Enable **Use New Input System** in the PlayerMovement script
4. Ensure the **Move Action** is assigned (default provided in prefab)

If not configured, the system will fall back to the legacy input system.

## Project Structure

```
Assets/AdventureToolkit/Movement/
  ├── Scripts/
  ├── Prefabs/
  └── Scenes/
```

## Movement Flow

```
Input Source
(WASD / Arrow Keys / Input Actions)
↓
Input Handling
(Legacy Input Manager or New Input System)
↓
Direction Processing
(Force 4-direction, no diagonal movement)
↓
Physics Application
(Rigidbody2D velocity in FixedUpdate)
```

## Technical Notes

- Requires Active Input Handling set to “Both” in Project Settings
- Uses Rigidbody2D for physics-based movement
- Implements 4-direction movement (no diagonal movement)
- Uses conditional compilation to support multiple input systems


## What This System Demonstrates

* Clean separation of input and movement logic
* Support for multiple Unity input systems
* 4-direction movement (classic top-down style)
* Reusable prefab-based design
* Beginner-friendly and extensible architecture

## Future Improvements

* Diagonal movement support
* Animation integration
* Expanded input options

## Additional Notes

For a deeper breakdown of how this system works — including input handling, physics updates, and design decisions — see:

[movement-system-notes.md](movement-system-notes.md)

### Need help customizing or extending this system?

I offer freelance help for Unity and game development:
[https://www.fiverr.com/lizziejperez](https://www.fiverr.com/lizziejperez)