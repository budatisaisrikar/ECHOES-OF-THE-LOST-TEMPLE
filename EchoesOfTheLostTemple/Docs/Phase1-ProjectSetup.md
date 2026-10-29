# Phase 1 — Project Setup & Player Movement

Phase 1 gives you a working Unity project with **Arin walking around a sealed test
room** using WASD/arrow keys, colliding correctly with walls. Time: about 45–60
minutes. No coding is needed beyond pasting one script (which is already in this pack).

By the end of this phase you will have:

- The exact folder structure the whole game will use
- A `Phase1_TestRoom` scene with a floor and four solid walls
- The **Arin** player GameObject with `PlayerController` attached
- Verified movement: 4-directional, normalized diagonals, solid walls

---

## 1. What you need

- **Unity Hub** (latest version) — free from unity.com/download
- One of these editor versions installed through Unity Hub:
  - **Unity 2022.3 LTS** (any 2022.3.x patch — recommended), or
  - **Unity 6 (6000.x)** — also fully supported; the provided script handles the
    small API differences automatically
- This project pack (the zip downloaded from the Dev Hub), unzipped

> If you are unsure which version to pick: install **Unity 2022.3 LTS**. It is the
> most stable and matches most beginner tutorials.

## 2. Create the Unity project

1. Open **Unity Hub** → **Projects** → **New project**.
2. Pick your editor version (2022.3 LTS recommended).
3. Choose the **2D** template. In 2022.3 it is called *2D (Built-in Render Pipeline)*;
   in Unity 6 you may see *Universal 2D* or *Built-in 2D* — **any 2D template works**
   because the game only uses SpriteRenderer, Rigidbody2D and BoxCollider2D.
4. Project name: `EchoesOfTheLostTemple`. Choose a folder you will find again.
5. Click **Create project**. Wait for the editor to open.

## 3. Copy this pack into the project

1. Close nothing — keep Unity open, it will import automatically.
2. From the unzipped pack, copy **everything** (the `Assets/` folder and the `Docs/`
   folder) into your project folder (the one that contains `Assets/`, `ProjectSettings/`).
   - Drag-and-drop into the project folder in your file manager, or
   - In Unity: drag the pack's `Assets` folder onto the Project window and accept the
     merge, then drag `Docs` onto the project folder row in the same window.
3. Back in Unity, watch the **Project window**: you should now see
   `Assets/Scripts/PlayerController.cs` and `Assets/Sprites/...`.
4. Check the **Console** (Window → General → Console): it should be free of red errors.

> `Docs/` intentionally lives at the project root, outside `Assets/`, so Unity does not
> import the guides as game assets.

## 4. One-time project setting (important)

The game scripts use Unity's classic Input Manager — the simplest input system for
beginners. New Unity 6 projects default to the new Input System only, which would
throw an `InvalidOperationException` at runtime.

1. Menu: **Edit → Project Settings → Player**
2. Expand **Other Settings** → scroll to **Configuration**
3. Set **Active Input Handling** to **Both**
4. The editor restarts itself — this is normal, wait for it to come back

That is the only global setting Phase 1 needs.

## 5. Build the Phase 1 test room

### 5.1 Create and save the scene

1. Menu: **File → New Scene** → choose **Empty** (or the default) → **Create**.
2. Save immediately: **File → Save As...** → navigate to `Assets/Scenes/` →
   file name `Phase1_TestRoom` → **Save**.

### 5.2 Camera

1. Select **Main Camera** in the Hierarchy.
2. In the Inspector set **Transform → Position** to `(0, 0, -10)`.
3. Confirm **Projection** is **Orthographic** (it is by default in 2D projects).
4. Set **Size** to `6` — the whole test room fits on screen.

### 5.3 Floor

1. Menu: **GameObject → 2D Object → Sprites → Square**. Rename it `Floor`.
2. Position `(0, 0, 0)`, Scale `(24, 14, 1)` — the square sprite is 1×1 unit, so this
   covers the whole room.
3. **Sprite Renderer → Color**: enter hex `334155` (stone grey). Click the color field,
   switch to Hex mode, paste, press Enter.
4. Optionally replace the square with the provided art: drag
   `Assets/Sprites/tile_stone_floor.png` into the **Sprite** field of the Sprite
   Renderer (import settings for the PNGs are in Section 7).

### 5.4 Walls (with real collision)

1. Create four more Squares (GameObject → 2D Object → Sprites → Square) and rename
   them `Wall_Top`, `Wall_Bottom`, `Wall_Left`, `Wall_Right`.
2. Give each one:
   - Color hex `1B2635` (dark charcoal), Scale `(26, 1, 1)` for top/bottom and
     `(1, 15, 1)` for left/right
   - Positions: Top `(0, 7.5, 0)`, Bottom `(0, -7.5, 0)`, Left `(-13.5, 0, 0)`,
     Right `(13.5, 0, 0)`
3. Select all four walls (click the first, Shift-click the last) → **Add Component →
   Physics 2D → Box Collider 2D**.
4. Make sure **Is Trigger** is **unchecked** on each collider. An unchecked
   BoxCollider2D is what physically blocks Arin.
5. Tidy the Hierarchy: **GameObject → Create Empty**, name it `Walls`, and drag the
   four walls onto it in the Hierarchy.
6. Save the scene (Ctrl/Cmd+S).

### 5.5 The player: Arin

1. Menu: **GameObject → 2D Object → Sprites → Square**. Rename it `Arin`.
2. Position `(0, 0, 0)`, Scale `(1, 1, 1)` — keep the default 1×1 size so the collider
   matches the sprite.
3. **Sprite Renderer → Color**: hex `06B6D4` (magic cyan) — or use the provided
   `Assets/Sprites/arin_idle.png` (see Section 7).
4. **Add Component → Scripts → PlayerController** (or drag the script onto the
   Inspector). Unity automatically adds a **Rigidbody2D** because of the
   `[RequireComponent]` line — never delete that Rigidbody2D.
5. On the **Rigidbody2D** component set:
   - **Body Type**: `Dynamic` (default)
   - **Collision Detection**: `Continuous`
   - Gravity Scale and Freeze Rotation are enforced by the script in `Awake()` —
     Gravity Scale `0` and Freeze Rotation checked are also correct in the Inspector.
6. Confirm Arin has a **BoxCollider2D** (added automatically with the Square; if not,
   Add Component → Physics 2D → Box Collider 2D).
7. Save the scene.

## 6. Press Play — what you should see

Press the **Play** button (▶ at the top center). Verify:

- **WASD and arrow keys** move Arin in all four directions
- **Diagonal movement** is not faster than straight movement (hold Up+Right and cross
  the room; it takes about the same time as holding Right alone)
- Arin **speeds up and slows down smoothly** (no instant start/stop)
- Arin **cannot walk through any wall** — try pushing into each one
- The sprite **flips** to face left/right while moving
- The **Console** shows no red errors
- Press Play again to stop; nothing you did in Play mode is saved (that is normal
  Unity behavior)

If all six points pass, Phase 1 is working — do not move to Phase 2 until they do.

## 7. Optional: use the placeholder pixel-art sprites

The pack ships three original placeholder PNGs in `Assets/Sprites/`. To get crisp
pixel art:

1. Select the PNG in the Project window.
2. In the Inspector set:
   - **Texture Type**: `Sprite (2D and UI)`
   - **Filter Mode**: `Point (no filter)` — this keeps pixels sharp
   - **Pixels Per Unit**: `32` for the two tiles, `16` for Arin
   - **Compression**: `None`
3. Click **Apply**.
4. Drag the sprite into the **Sprite** field of the target's Sprite Renderer
   (`Floor`, the walls, or `Arin`).
5. If a tile comes in too large or small, adjust the object's Scale — the collider is
   what matters, not the sprite size.

## 8. If something goes wrong

- **"InvalidOperationException: You are trying to read Input using the
  UnityEngine.Input class..."** — you skipped Section 4. Set Active Input Handling to
  **Both** and let the editor restart.
- **Arin falls down and disappears** — the Rigidbody2D has Gravity Scale > 0 and the
  PlayerController script was removed. Re-add the script; it forces Gravity Scale to 0.
- **Arin walks straight through walls** — a wall is missing its BoxCollider2D, or
  **Is Trigger** is checked, or Arin's BoxCollider2D was deleted. Fix the collider.
- **"Can't add script component..." / class name error** — the file must be named
  exactly `PlayerController.cs` (the class name and file name must match) and must sit
  inside `Assets/`.
- **No movement at all** — check the Console for red errors; make sure the Game view
  has focus (click once inside it) so Unity receives your key presses.
- **"2D Object" is missing from the GameObject menu** — the project was created from a
  3D template. Recreate it with a 2D template (Section 2).
- **Arin vibrates against a wall** — set the Rigidbody2D **Collision Detection** to
  `Continuous` (Section 5.5, step 5).

## 9. Phase 1 exit criteria

Tick every box in `Docs/TestingChecklist-Phase1.md`. When all pass, Phase 1 is
complete — then (and only then) continue to Phase 2: pushing blocks, pressure plates,
switches and doors.
