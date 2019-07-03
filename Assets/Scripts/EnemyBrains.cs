using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy_Health))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(LongShot))]
public class EnemyBrains : MonoBehaviour
{
    public Rigidbody2D player;
    private Rigidbody2D enemyRB;
    private bool isFacingLeft;
    public Transform PlayerTransform;
    private Enemy_Health health;
    private SpriteRenderer sprite;
    private LongShot longShot;

    private bool holderIsCurrent;
    private bool isMoving;
    private Vector2 holderPosition;

    private float fireCD;
    private static float fireCDHolder = 1f;

    bool IsInLineOfVision()
    {
        bool IsInVision = false;

        return IsInVision;
    }

    bool IsValidPosition(Vector2 pos)
    {
        // Add code to check if the position is a valid square

        return true;
    }

    void Shoot()
    {
        longShot.Shoot();
    }

    void Idle()
    {
        if (isMoving)
        {

            // If we need a new position then make it
            if (holderIsCurrent == false)
            {
                do
                {
                    holderPosition = new Vector2(Random.Range(-20, 20), Random.Range(-15, 15));
                    holderIsCurrent = true;
                } while (!IsValidPosition(holderPosition));
            }

            // Go to the position
            enemyRB.position = Vector2.MoveTowards(enemyRB.position, holderPosition, 2f * Time.deltaTime);

            if ((enemyRB.position - holderPosition).magnitude < 1)
            {
                holderIsCurrent = false;
                isMoving = false;
            }

            if (enemyRB.position.x - holderPosition.x < 0)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
        else
        {
            // Idle

            isMoving = Random.Range(0, 100) == 95;
        }
    }

    void Searching()
    {
        enemyRB.position = Vector2.MoveTowards(enemyRB.position, player.position, 4f * Time.deltaTime);
        holderIsCurrent = false;
        isMoving = false;
    }

    void Attacking()
    {
        // Get Angle
        float rotZ = Mathf.Atan2(player.position.y - enemyRB.position.y, player.position.x - enemyRB.position.x) * Mathf.Rad2Deg;
        PlayerTransform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        
        Invoke("Shoot", .5f);
        fireCD = fireCDHolder;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        isMoving = false;
        bool xNegative;
        bool yNegative;

        xNegative = Random.Range(1, 3) % 2 == 0;
        yNegative = Random.Range(1, 3) % 2 == 0;
        

        holderIsCurrent = false;
        fireCD = 0;
        longShot = GetComponent<LongShot>();
        health = GetComponent<Enemy_Health>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        if (fireCD <= 0 && health.health > 0)
        {
            if ((player.position - enemyRB.position).magnitude > 7)
            {
                Idle();
            }
            else if ((player.position - enemyRB.position).magnitude <= 5)
            {
                Attacking();
            }
            else
            {
                Searching();
            }
        }
        else if (health.health > 0)
        {
            fireCD -= Time.deltaTime;
        }
    }
}
