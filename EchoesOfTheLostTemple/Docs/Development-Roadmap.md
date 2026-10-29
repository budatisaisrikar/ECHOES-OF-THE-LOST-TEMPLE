# Development Roadmap — Echoes of the Lost Temple

The full build plan (Section 14 of the design document). Phase 1 is delivered in this
pack; the remaining phases are added one at a time, each only after the previous phase
passes its testing checklist.

## Phase 1 — Project setup (DELIVERED)

- Unity project structure: Scenes, Scripts, Prefabs, Sprites, Tilemaps, Materials,
  Audio, UI
- `Assets/Scripts/PlayerController.cs` — top-down movement, normalized diagonals,
  smooth acceleration, 2D collision
- `Phase1_TestRoom` scene walkthrough + manual test checklist

## Phase 2 — Core interactions (planned)

- `PushableBlock.cs` — stone blocks that slide one grid cell per push, blocked by
  walls, other blocks and closed doors
- `PressurePlate.cs` — changes color when a block rests on it; drives connected doors
- `SwitchController.cs` — E-to-activate switches with visible state change
- `DoorController.cs` — opens/closes from plate, switch or crystal conditions; closed
  doors are solid colliders
- `PlayerInteraction.cs` — the E-key interaction system

## Phase 3 — Magical mechanics (planned)

- `Teleporter.cs` — linked portal pairs, arrival safety (no re-trigger loops), short
  teleport effect
- `CrystalCollectible.cs` — one-time pickup, counter updates, "Crystal collected!"
  notification, doors that require N crystals
- `GameManager.cs` — crystal count, mute option, room-independent state

## Phase 4 — Level progression (planned)

- The five rooms: Forgotten Entrance, Chamber of Weight, Hall of Switches, Portal
  Sanctuary, Heart of the Temple
- `RoomManager.cs` — room loading, spawn points, completed-room flags so crystals are
  never collected twice
- Crystal count persists across room transitions

## Phase 5 — UI and polish (planned)

- Main menu, instructions screen, HUD (crystal counter, room name, prompts), pause
  menu, victory screen ("The Temple's Secret Has Been Restored!")
- `UIManager.cs` + `MainMenuController.cs`
- Sound effects and gentle particle effects (optional, game runs silent without them)

## Phase 6 — Final testing (planned)

- Full 10–15 minute playthrough against the master checklist
- Windows build instructions, macOS build instructions
