# Gridventure Toolkit: Top-Down Movement System (Unity C#)

**Current Version:** v2.0

A reusable, adventure game–inspired 2D top-down movement system built with Unity’s **New Input System**, designed for clarity, flexibility, and easy integration.
Built in Unity with C#, this beginner-friendly system provides clean, responsive 4-direction movement with vertical input priority for precise control, with optional diagonal movement support.
Includes a ready-to-use demo environment with 16x16 pixel art assets and prefabs for quick prototyping and testing.

## Features

### v2.0

* 4-directional movement (up, down, left, right)
* Optional diagonal movement (toggle in Inspector)
* Smooth and responsive controls
* Adjustable movement speed via Inspector
* Built with Unity’s New Input System
* Supports keyboard and controller input through a `Move` action
* Uses `Rigidbody2D` physics with velocity applied in `FixedUpdate`
* Simple, readable C# implementation
* Ready-to-use demo scene for testing and integration
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
* Gamepad Left Stick — Move

## How to Use

1. Open the project in Unity (tested with Unity 6 LTS)
2. Open the demo scene:
   `Assets/GridventureToolkit/Movement/Scenes/DemoScene`
3. Press Play to test movement

### Customize

* Adjust movement speed in the Player Inspector
* Toggle **Allow Diagonal Movement** in the `PlayerMovement` component
* Enable **Debug Mode** to log raw movement inputs

## Input System Reference

This project uses Unity’s **New Input System**.

For information see the official documentation here: [https://docs.unity3d.com/Packages/com.unity.inputsystem@1.6/manual/index.html](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.6/manual/index.html)

## Project Structure

```
Assets/GridventureToolkit/
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
(WASD / Arrow Keys / Gamepad Left Stick)
↓
Input Actions Asset
(Player map → Move action)
↓
PlayerInput
(Invoke C# Events)
↓
Direction Processing
(Force 4-direction, no diagonal movement)
↓
Physics Application
(Rigidbody2D linear velocity in FixedUpdate)
```

## Technical Notes

* Requires `Rigidbody2D` and `PlayerInput`
* Uses Unity’s New Input System
* Uses `PlayerInput` with C# event callbacks
* Uses `Rigidbody2D` for physics-based movement
* Implements 4-direction movement with no diagonal movement
* Vertical movement is prioritized when horizontal and vertical input weights are equal


## What This System Demonstrates

* Clean separation of input and movement logic
* Unity New Input System workflow using `PlayerInput`
* 4-direction movement (classic top-down style)
* Reusable prefab-based design
* Beginner-friendly and extensible architecture

## Future Improvements

* Animation integration
* Facing direction output for animation systems
* Interaction system integration
* Expanded input options

## Previous Version Demo (v1.1)

Demo Video: [https://youtu.be/QXQprQBhzHk](https://youtu.be/QXQprQBhzHk)

## Additional Notes

For a deeper breakdown of how this system works — including input handling, physics updates, and design decisions — see:

[movement-system-notes.md](movement-system-notes.md)

## Need help customizing or extending this system?

I offer freelance help for Unity and game development:
[https://www.fiverr.com/lizziejperez](https://www.fiverr.com/lizziejperez)