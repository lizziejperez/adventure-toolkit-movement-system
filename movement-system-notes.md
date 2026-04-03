# Movement System — Notes & Concepts

**Script**: PlayerMovement.cs

## Overview

This system implements a simple **top-down 2D movement controller** in Unity using C#.

It uses Rigidbody2D physics to move a player smoothly in four directions, with optional diagonal movement.

This system supports Unity's new Input System.

## System Breakdown

The movement system is responsible for:

* Reading player input (Move action Vector2)
* Determining movement direction (4-directional, no diagonal priority)
* Applying velocity using Rigidbody2D
* Ensuring smooth and responsive movement

Core components:

* Rigidbody2D for physics-based movement
* Input handling using Unity's New Input System (`PlayerInput`, `InputAction`)

## Design Decisions

* Input System support instead of Input Manager
* Single player game support -> use `PlayerInput` component
* Diagonal movement is optional and controlled via an Inspector toggle (`allowDiagonalMovement`)

## Movement Priority Rules

* When diagonal movement is disabled:
    * Axis of input with the most weight will be the direction of movement
    * In cases of equal weights, vertical movement will be prioritized
* When diagonal movement is enabled:
    * Full input vector is used without filtering

## Script Notes

* `Awake()` caches required component references and fetches the Move action
* `OnEnable()` subscribes to input action events
* `OnDisable()` unsubscribes from input action events
* `OnMoveStarted`, `OnMovePerformed`, and `OnMoveCanceled` update the stored input vector
* `FixedUpdate()` filters the vector to one cardinal direction and applies movement using rb.linearVelocity

## References Used

Primarily referenced the official Unity documentation and class notes.

* Unity 6 LTS Documentation: https://docs.unity3d.com/6000.3/Documentation/Manual/index.html
* Unity Input System documentation: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.5/manual/Concepts.html
* Unity scripting and 2D physics documentation: https://docs.unity3d.com/6000.3/Documentation/Manual/2d-physics/2d-physics.html
* Unity execution order documentation: https://docs.unity3d.com/2021.2/Documentation/Manual/ExecutionOrder.html
* Scripting API references: https://docs.unity3d.com/6000.3/Documentation/ScriptReference/