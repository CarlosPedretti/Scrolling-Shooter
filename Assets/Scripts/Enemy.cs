using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    //public Animator animator;

    public Enemy enemy;
    public CircleCollider2D circleCollider;




    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 10;

    private Rigidbody2D rb;
    public float speed = 5f;
    //public GameObject explosionPrefab;


    void Awake()
    {

    }

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();


    }


    void Update()
    {
        rb.velocity = new Vector2(0, -speed);
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Movement playerHealth = collision.gameObject.GetComponent<Movement>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(enemy.damage);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collision"))
        {
            CircleCollider2D circleCollider = other.GetComponent<CircleCollider2D>();
            if (circleCollider != null)
            {
                circleCollider.enabled = true;
            }
        }
    }



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            //animator.SetTrigger("Hurt");
        }

    }
}
