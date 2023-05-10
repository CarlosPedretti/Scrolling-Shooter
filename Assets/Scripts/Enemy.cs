using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    //public Animator animator;

    public Enemy enemy;


    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 10;

    private Rigidbody2D rb;
    public float speed = 5f;
    //public GameObject explosionPrefab;




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
