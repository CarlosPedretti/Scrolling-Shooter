using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{



    public Shots shotsScript;

    public int maxHealth = 100;
    public int currentHealth;


    public float speed = 5f;
    public float drag = 5f;
    public Rigidbody2D rb;

    public GameObject explosionPrefab;

    public float delay = 15f;





    private bool canPassThroughWall = true;


    void Start()
    {
        currentHealth = maxHealth;
        shotsScript = GetComponent<Shots>();
    }


    void FixedUpdate()
    {

        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(speed * inputX, speed * inputY);

        rb.AddForce(movement * speed);


        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }

        rb.velocity *= (1f - drag * Time.fixedDeltaTime);





    }


    void OnCollisionEnter2D(Collision2D colider)
    {
        if (colider.gameObject.tag == "Enemy")
        {
            shotsScript.DeactivatePowerUp();

            Enemy enemyHealth = colider.gameObject.GetComponent<Enemy>();


                enemyHealth.EnemyDie();

            Die();

        }
        if (colider.gameObject.tag == "Win")
        {
            GameManager.Instance.WinScreen();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (!canPassThroughWall)
            {

                rb.velocity = Vector2.zero;
            }
        }
        if (other.gameObject.tag == "PowerUp")
        {
            shotsScript.ActivatePowerUp();
            Destroy(other.gameObject);


            Invoke("DeactivatePowerUp", delay);
        }


    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {

        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 0.4f);
        Destroy(gameObject);
        GameManager.Instance.ShowGameOverScreen();
    }

    public void ResetHealth()
    {
        currentHealth = 0;
    }

    private void DeactivatePowerUp()
    {
        shotsScript.DeactivatePowerUp();
    }




}
