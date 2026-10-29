# Phase 1 — Manual Testing Checklist

Run every test in `Phase1_TestRoom` (Section 5 of the setup guide). Tick a box only
after you have seen it pass with your own eyes. If any box fails, fix it before
starting Phase 2.

## Movement

- [ ] W / Up arrow moves Arin up; S / Down arrow moves Arin down
- [ ] A / Left arrow moves Arin left; D / Right arrow moves Arin right
- [ ] Holding Up + Right together moves diagonally, and it does NOT feel faster than
      holding Right alone (both cross the room in about the same time)
- [ ] Arin starts and stops smoothly (small acceleration/deceleration, no snapping)
- [ ] Releasing all keys brings Arin to a stop

## Collision

- [ ] Arin cannot walk through the top wall (push against it for a full second)
- [ ] Arin cannot walk through the bottom wall
- [ ] Arin cannot walk through the left wall
- [ ] Arin cannot walk through the right wall
- [ ] Arin cannot walk through a wall while moving diagonally into it
- [ ] Arin stays inside the room no matter how long you hold a direction

## Stability

- [ ] The sprite flips to face left when moving left, right when moving right
- [ ] The Console (Window → General → Console) shows no red errors during play
- [ ] Stopping Play mode and pressing Play again restarts Arin at (0, 0, 0) with no
      errors (Play mode changes are never saved — this confirms it)
- [ ] Saving the scene, closing and reopening the project keeps the room intact
