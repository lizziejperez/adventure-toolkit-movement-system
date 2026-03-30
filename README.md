# Adventure Toolkit: Top-Down Movement System (Unity C#)

**Current Version:** v1.1

Demo Video: [https://youtu.be/QXQprQBhzHk](https://youtu.be/QXQprQBhzHk)

A reusable, adventure game–inspired 2D top-down movement system with support for both Unity input systems — designed for clarity, flexibility, and easy integration.

Built in Unity with C#, this beginner-friendly system provides clean, responsive 4-direction movement with vertical input priority for precise control.

Includes a ready-to-use demo environment with 16x16 pixel art assets and prefabs for quick prototyping and testing.

## Features

### v1.0

* 4-directional movement (up, down, left, right)
* Smooth and responsive controls
* Adjustable movement speed via Inspector
* Simple, readable C# implementation
* Ready-to-use demo scene for testing and integration
* Supports both Unity Input Manager and the new Input System (toggleable in Inspector)

### v1.1

* Includes 16x16 pixel demo assets (player, trees, rocks, bushes)
* Environment prefabs for rapid scene building

## Who It’s For

Perfect for:
* Beginners learning game development
* Building top-down adventure games
* Expanding into more complex systems

Use this as a foundation for your own projects.

## Controls

* W / A / S / D — Move
* Arrow Keys — Move

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
Assets/AdventureToolkit/
  ├── Movement/
  |    ├── Prefabs/
  |    └── Scripts/
  ├── Demo/
  |    ├── Prefabs/
  |    └── Scenes/
  └── Art/ ← Demo 16x16 pixel assets (player, environment)
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