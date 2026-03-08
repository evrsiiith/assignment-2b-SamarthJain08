[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/FDtpdb9Z)

# EVRS Assignment 2 — Quick Test Guide

**Controls**
- Movement: `W` / `Up Arrow` = step forward
- Movement: `S` / `Down Arrow` = step backward
- Movement: `A` = step left
- Movement: `D` = step right
- Turning: `Q` / `Left Arrow` = turn left (smooth or step depending on controller)
- Turning: `E` / `Right Arrow` = turn right
- Interact (click): Left mouse button (click an interactable object while looking at it)
- Temperature slider: Mouse scroll while looking at the `TempSlider` (requires AC on)

Notes: Movement and turning are implemented in `Assets/Scripts/CameraController.cs`.

**Primary interactions & where to find them**
- Light switch: `Assets/Scripts/LightSwitchController.cs` / object name `LightSwitch`
  - Click or use the switch in-scene to toggle `light1` and `light2`.
  - Visual indicator: the switch renderer changes color (yellow=on, gray=off).
  - Auto ON: entering the room should turn lights on if the scene uses the `RoomTrigger` logic.
- Room trigger (auto lights): `Assets/Scripts/RoomTrigger.cs`
  - When the camera/player enters the room trigger, it sets `lightsOn = true` and enables the lights.
  - If lights are not auto-turning on, check tags and colliders (see Troubleshooting).
- Door: `Assets/Scripts/DoorController.cs` / object name `Door`
  - Click the door (or use hinge interaction) to toggle open/closed.
  - When open, collider is disabled and rotation set to 90°; when closed, rotation set to 0°.
- AC switch & temperature: `Assets/Scripts/ACSwitchController.cs`
  - Click the `ACSwitch` to toggle AC on/off. Visual indicator is renderer color (cyan = on).
  - When AC is on, look at the `TempSlider` and use mouse wheel to increase/decrease temperature.
  - TV display updates with warnings when temperature is high or AC/door cause energy waste.
- Generic interaction raycasting: `Assets/Scripts/InteractionRaycaster.cs`
  - Left-click sends `Interact` to the hit collider (max range 10 units).
  - Interactable components implement an `Interact()` method (e.g. `LightSwitchController`, `DoorController`).

**What to try (smoke tests)**
1. Play scene. Walk to the door area using WASD/arrow keys; try turning with Q/E.
2. Click the LightSwitch — lights should toggle and switch color should change.
3. Click the Door — door should open (rotate) and collider should disable; click again to close.
4. Toggle AC switch; when AC is on, look at `TempSlider` and spin mouse wheel — temperature should change and TV updates may appear.
5. Walk into the room trigger area (near the room entrance): lights should auto-turn on (if `RoomTrigger` collider and tags are correct).

**Expected state/visual cues**
- Lights on: `RoomLight` and `LightSwitch` visuals change and `RenderSettings.ambientLight` becomes brighter.
- Door open: `Door` rotation = (0,90,0) and `GameState.Instance.doorOpen = true`.
- AC on: `GameState.Instance.acOn = true` and `ACSwitch` renderer = cyan.
- Temperature change: `TempSlider` color changes; TV may display warning colors.

**Common issues & troubleshooting**
- NullReferenceException in `InteractionRaycaster.Update` at `Camera.main`:
  - Ensure your scene has a Camera GameObject tagged `MainCamera`. Unity's convenience property `Camera.main` returns the camera tagged `MainCamera`.
- Auto lights not turning on when entering room:
  - Confirm the trigger collider object has the correct trigger area and `IsTrigger` enabled.
  - Verify which object enters the trigger: `RoomTrigger` checks the entering collider's tag (`MainCamera` in current code). It's common for the player's collider to be tagged `Player` instead — update the check or tag accordingly.
  - Ensure the camera/player object actually collides with the trigger (cameras often have no colliders). Alternative approach: change `RoomTrigger` to look for the player tag or detect a `Camera` component on `other`.
- Lights not toggling on click:
  - Ensure `LightSwitch` object has `LightSwitchController` with `light1`/`light2` assigned in inspector.
  - Confirm raycast distance (10f) in `InteractionRaycaster` is sufficient for your camera distance.
- Door doesn't open:
  - Make sure `doorCollider` is assigned in the `DoorController` component in the inspector.

**Inspector checklist before testing**
- `Main Camera` tagged `MainCamera`.
- `GameState` object present in scene (script registers `Instance` in Awake).
- `LightSwitch`, `RoomLight`, `ACSwitch`, `Door`, `TempSlider`, `TVScreen` exist and - where required - have their script references assigned (lights, colliders, renderers).

**Where the logic lives**
- Movement & continuous controls: `Assets/Scripts/CameraController.cs`
- Click-to-interact raycast: `Assets/Scripts/InteractionRaycaster.cs`
- Light switch logic: `Assets/Scripts/LightSwitchController.cs`
- Door logic: `Assets/Scripts/DoorController.cs`
- AC logic: `Assets/Scripts/ACSwitchController.cs`
- Global state and scene visuals: `Assets/Scripts/GameState.cs`
- High-level user algorithm helpers and testable behaviors: `UserAlgorithms.cs` (root)

---
