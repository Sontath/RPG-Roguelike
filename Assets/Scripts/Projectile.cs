using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 velocity;
    public float speed;
    public float damage;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
        rb.velocity = transform.right * speed;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit an object");
        // Deal Damage
        Enemy_Health enemy = other.GetComponent<Enemy_Health>();

        if (enemy != null)
        {
            enemy.DealDamage(damage);
        }

        // Destroy the bullet 
        Destroy(gameObject);
    }
}
