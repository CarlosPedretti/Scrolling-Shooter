using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //public Vector2 speed = new Vector2 (20, 20);

    public int maxHealth = 100;
    public int currentHealth;

    public float speed = 5f;
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

        //Vector2 movement = new Vector2 (speed.x * InputX, speed.y * InputY);

        //movement *= Time.deltaTime;

        //transform.Translate(movement);

        Vector2 movement = new Vector2(speed * InputX, speed * InputY);

        rb.velocity = movement;



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

    /*public void TogglePassThroughWall(bool allowPassThrough)
    {
        canPassThroughWall = allowPassThrough;
    }*/



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
