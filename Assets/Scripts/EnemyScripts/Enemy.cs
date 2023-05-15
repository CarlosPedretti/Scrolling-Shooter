using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public Enemy enemy;



    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 10;

    private Rigidbody2D rb;
    public float Rbspeed = 5f;
    public GameObject explosionPrefab;
    private bool hasExploded = false;


    void Awake()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }


    void Update()
    {
        rb.velocity = new Vector2(0, -Rbspeed);

    }



    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            Movement playerHealth = collision.gameObject.GetComponent<Movement>();

            if (playerHealth != null)
            {
                playerHealth.ResetHealth();
            }

        }



    }

    public void ResetHealth()
    {
        currentHealth = 0;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && !hasExploded)
        {
            EnemyDie();
        }




    }

    public void EnemyDie()
    {
        hasExploded = true;
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 0.4f);
        Destroy(gameObject);
    }
}
