using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{



    public int maxHealth = 100;
    public int currentHealth;

    public float speed = 5f;
    public float drag = 5f;
    public Rigidbody2D rb;

    //private Animator Animator;
    private float LastShoot;
    public GameObject BulletPrefab;
    public Transform BulletSpawn;

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


        //Disparo
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (!canPassThroughWall)
            {
                // Evitar que el jugador sobrepase el objeto "Wall"
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


    private void Shoot()
    {
        GameObject newBulletPrefab = BulletPrefab;

        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.up;
        else direction = Vector3.up;

        GameObject bullet = Instantiate(newBulletPrefab, BulletSpawn.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }


}
