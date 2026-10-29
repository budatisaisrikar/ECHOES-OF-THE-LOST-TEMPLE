# Echoes of the Lost Temple — Unity Project Source

This folder is the **real game project source** for *Echoes of the Lost Temple*, a 2D
top-down puzzle adventure built in **Unity with C# scripts**. The web Dev Hub that hosts
these files is only a documentation/download page — the game itself runs in Unity.

**Current status: Phase 1 delivered** (project setup, folder structure, player movement
and collision). Phases 2–6 are planned in `Docs/Development-Roadmap.md`.

## What you need

- Unity Hub (latest) with **Unity 2022.3 LTS** or **Unity 6 (6000.x)** installed.
- The downloaded project zip (this folder), unzipped anywhere you like.

## Quick start — 4 steps

1. **Create a Unity project**: Unity Hub → *New project* → pick your editor version →
   choose a **2D** template → name it `EchoesOfTheLostTemple` → *Create*.
2. **Copy this pack in**: copy the contents of this folder (the `Assets/` folder and the
   `Docs/` folder) into your new project folder, merging with its existing `Assets/`.
   Unity imports the files automatically.
3. **One settings change**: Edit → Project Settings → Player → Other Settings →
   *Active Input Handling* → **Both** (lets the scripts use Unity's classic Input
   Manager). The editor restarts — that is normal.
4. **Follow the guide**: open `Docs/Phase1-ProjectSetup.md` and build the Phase 1 test
   room step by step, then play-test with the checklist in `Docs/TestingChecklist-Phase1.md`.

## Folder map

```
EchoesOfTheLostTemple/
├── Assets/
│   ├── Scenes/      Phase scenes are created here (Phase1_TestRoom.unity)
│   ├── Scripts/     C# gameplay scripts (Phase 1: PlayerController.cs)
│   ├── Prefabs/     Reusable objects: blocks, switches, doors, crystals, portals
│   ├── Sprites/     Original placeholder pixel art (Arin + temple tiles)
│   ├── Tilemaps/    Tile assets and palettes (later phases)
│   ├── Materials/   Physics materials and sprite materials (later phases)
│   ├── Audio/       Sound effects (later phases; the game runs fine without them)
│   └── UI/          UI sprites and assets (later phases)
└── Docs/
    ├── Phase1-ProjectSetup.md     Beginner setup guide for Phase 1
    ├── TestingChecklist-Phase1.md Manual test checklist for Phase 1
    └── Development-Roadmap.md     The Phase 1–6 build plan
```

## Placeholder art

The PNGs in `Assets/Sprites/` are **original generated placeholders** (Arin, a stone
floor tile, a stone wall tile) so the game looks the part before real art exists.
You can equally use Unity's built-in Square sprite — the Phase 1 guide shows both
routes. Everything here is original; no copyrighted assets are used.
