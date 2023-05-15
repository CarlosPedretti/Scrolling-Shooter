using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 25f;
    //public int Damage;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;

    private Enemy enemy;




    private void Start()
    {

        enemy = FindObjectOfType<Enemy>();

        Rigidbody2D = GetComponent<Rigidbody2D>();


    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * speed;

    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }



    void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {


        Movement movement = hitInfo.GetComponent<Movement>();
        if (movement != null)
        {
            movement.TakeDamage(enemy.damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}