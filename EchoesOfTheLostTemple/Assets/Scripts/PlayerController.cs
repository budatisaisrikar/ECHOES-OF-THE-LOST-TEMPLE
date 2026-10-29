// ============================================================================
// Echoes of the Lost Temple — Phase 1
// PlayerController.cs
//
// WHERE THIS FILE BELONGS
//   Assets/Scripts/PlayerController.cs
//
// WHAT IT DOES
//   • Top-down 8-direction movement for Arin (WASD + arrow keys)
//   • Normalizes diagonal input so moving diagonally is NOT faster
//   • Smooth acceleration when starting, smooth deceleration when stopping
//   • Uses Unity 2D physics, so Arin can never walk through wall colliders
//
// HOW IT IS SET UP (full walkthrough: Docs/Phase1-ProjectSetup.md)
//   1. Attach this component to the "Arin" GameObject.
//      A Rigidbody2D is added automatically (RequireComponent below).
//   2. Arin also needs a BoxCollider2D (Component > Physics 2D > Box Collider 2D).
//   3. Every wall needs a BoxCollider2D with "Is Trigger" turned OFF.
//   4. The script hardens the Rigidbody2D in Awake():
//        Gravity Scale = 0        (a top-down world never pulls Arin downward)
//        Freeze Rotation = on     (bumping a wall must not tip Arin over)
//        Collision Detection = Continuous (no tunneling through thin walls)
//
// INPUT NOTE
//   This script reads the classic Input Manager axes ("Horizontal"/"Vertical").
//   If your project uses the new Input System only, Unity throws
//   "InvalidOperationException: You are trying to read Input using the
//   UnityEngine.Input class...". Fix: Edit > Project Settings > Player >
//   Other Settings > Active Input Handling -> "Both".
// ============================================================================

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Top speed in units per second.")]
    [SerializeField] private float moveSpeed = 5f;

    [Tooltip("How fast Arin speeds up, in units per second per second.")]
    [SerializeField] private float acceleration = 40f;

    [Tooltip("How fast Arin slows down when input is released.")]
    [SerializeField] private float deceleration = 60f;

    [Tooltip("Flip the sprite so Arin faces the horizontal move direction.")]
    [SerializeField] private bool flipSpriteToFaceMovement = true;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveInput;       // raw WASD/arrow input, normalized for diagonals
    private Vector2 currentVelocity; // cached so other scripts (Phase 2+) can read it

    /// <summary>The direction Arin is currently facing (set from input).</summary>
    public Vector2 FacingDirection { get; private set; } = Vector2.down;

    /// <summary>Arin's current velocity — handy for later phases (animations, pushing).</summary>
    public Vector2 Velocity => currentVelocity;

    // Unity 6 renamed Rigidbody2D.velocity to linearVelocity. This tiny shim
    // keeps the same code warning-free on Unity 2022.3 LTS and Unity 6.
#if UNITY_6000_0_OR_NEWER
    private Vector2 BodyVelocity
    {
        get => body.linearVelocity;
        set => body.linearVelocity = value;
    }
#else
    private Vector2 BodyVelocity
    {
        get => body.velocity;
        set => body.velocity = value;
    }
#endif

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Null check: a sprite is recommended but not required to move.
        if (spriteRenderer == null)
        {
            Debug.LogWarning("PlayerController: no SpriteRenderer found — sprite flipping disabled.");
        }

        // --- Top-down safety net (also explained in the setup guide) ---
        body.gravityScale = 0f;                    // no falling in a top-down game
        body.freezeRotation = true;                // walls must not tip Arin over
        body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Update()
    {
        ReadMoveInput();
        UpdateFacing();
    }

    private void FixedUpdate()
    {
        // Physics movement happens here so collisions stay stable.
        Vector2 targetVelocity = moveInput * moveSpeed;
        float rate = moveInput.sqrMagnitude > 0.01f ? acceleration : deceleration;
        currentVelocity = Vector2.MoveTowards(BodyVelocity, targetVelocity, rate * Time.fixedDeltaTime);
        BodyVelocity = currentVelocity;
    }

    private void ReadMoveInput()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D and left/right arrows
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S and up/down arrows

        // Normalize diagonals: (1, 1) has length ~1.41, so scale it down to 1.
        // This is what keeps diagonal movement from being faster.
        if (moveInput.sqrMagnitude > 1f)
        {
            moveInput.Normalize();
        }
    }

    private void UpdateFacing()
    {
        if (moveInput.sqrMagnitude < 0.01f)
        {
            return; // keep the last facing direction while standing still
        }

        FacingDirection = moveInput.normalized;

        if (flipSpriteToFaceMovement && spriteRenderer != null && Mathf.Abs(moveInput.x) > 0.01f)
        {
            spriteRenderer.flipX = moveInput.x < 0f;
        }
    }
}
