using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 25;


    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;


    private Shots shotScript;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        shotScript = FindObjectOfType<Shots>();


    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;

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


        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(shotScript.BulletDamage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}