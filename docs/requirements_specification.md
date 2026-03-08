# Smart Bedroom - Requirements Specification

## Scene Description
You begin outside a smart bedroom. Use raycast to trigger the door open. Upon entering, the light automatically turns ON. Inside, you can toggle the AC on/off and adjust temperature via slider. The system monitors room conditions and alerts you if AC is running with the door open (wasting energy) or if temperature exceeds 28°C. The light can be manually turned off and automatically turns back ON each time you re-enter.

## Interactive Objects

1. **Door** - Door that rotates open/closed (0° to 90° rotation, raycast-triggered)
2. **Light Switch** - Room lighting control (on/off states, color feedback)
3. **Temperature Control Panel** - AC on/off switch + temperature slider (15°C to 35°C)
4. **TV Screen** - Displays warnings and system alerts

## Actions

1. **Open/Close Door** - Point and trigger (raycast) door to toggle between open and closed
2. **Toggle Light** - Point and trigger light switch to turn off/on
3. **Toggle AC** - Point and trigger AC switch to turn on/off
4. **Adjust Temperature** - Interact with slider to set room temperature (when AC is on)

## State Changes

1. **Door State** - CLOSED (0°) → OPEN (90°) → CLOSED (triggered via raycast)
2. **Light State** - AUTO ON (bright white-yellow) on entry → OFF (dark gray) manually → AUTO ON on re-entry
3. **AC State** - OFF → ON (toggled via raycast trigger)

## Conditional Logic Rules

### Rule 1: Temperature Warning
- **Condition**: IF Temperature > 28°C
- **Action**: Display a warning as a RED screen (High temp)
- **Reset**: IF Temperature ≤ 28°C, clear warning

### Rule 2: Energy Waste Alert
- **Condition**: IF AC is ON AND Door is OPEN
- **Action**: Display a warning as a YELLOW screen (Energy waste), or ORANGE screen (if temp is high too)
- **Reset**: IF AC is OFF OR Door is CLOSED, clear alert
