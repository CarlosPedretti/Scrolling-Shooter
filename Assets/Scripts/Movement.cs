using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Movement player;


    public int maxHealth = 100;
    public int currentHealth;


    public float speed = 5f;
    public float drag = 5f;
    public Rigidbody2D rb;

    //private Animator Animator;


    private bool canPassThroughWall = true;


    void Start()
    {
        currentHealth = maxHealth;
    }


    void FixedUpdate()
    {
        //Movimiento
        float InputY = Input.GetAxis("Vertical");
        float InputX = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(speed * InputX, speed * InputY);

        rb.AddForce(movement * speed);


        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }

        rb.velocity *= (1f - drag * Time.fixedDeltaTime);





    }



    /*void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "EnemyBullet")
        {
            Enemy enemyHealth = collision.gameObject.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bullet.damage);
            }
        }
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (!canPassThroughWall)
            {

                rb.velocity = Vector2.zero;
            }
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            GameManager.Instance.ShowGameOverScreen();
        }

    }

    public void ResetHealth()
    {
        currentHealth = 0;
    }




}
