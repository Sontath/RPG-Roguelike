using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private InputHandler input;
    [Header("Player Settings")]
    [SerializeField]
    [Range(1, 10)]
    private float speed;
    private Rigidbody2D rb;
    [SerializeField]
    private ClassBehavior cBehavior;

    [Header("Primary settings")]
    [SerializeField]
    [Range(0, 5)]
    private float SavedFireBallCoolDown;
    private float PrimaryCoolDown;
    //[Space(10)] // 10 pixels of spacing here

    private Vector2 movement;
    private SpriteRenderer sr;

    private void Attack()
    {
        PrimaryCoolDown = SavedFireBallCoolDown;
        cBehavior.PrimaryAttack();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate new objects
        movement = new Vector2();

        // Set default values
        PrimaryCoolDown = 0f;

        // Get components
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Perform action buttons
        
        // if cooldown is under 0, fire a fireball.
        if (PrimaryCoolDown <= 0)
        {
            // reset the cd timer
            if (input.GetAttackBtn())
            {
                Attack();
            }
        }
        // If cooldown is over 0 decrease cooldown
        else
        {
            PrimaryCoolDown -= Time.deltaTime;
        }

        // Perform movement
        movement.x = input.GetMovementHorizontal();
        movement.y = input.GetMovementVertical();
        movement = movement.normalized * speed;

        // Flip charecter
        if (input.GetMovementHorizontal() > 0f)
        {
            sr.flipX = false;
        }
        else if (input.GetMovementHorizontal() < 0f)
        {
            sr.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        // Move our charecter by movement
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
