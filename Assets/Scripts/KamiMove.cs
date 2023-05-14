using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KamiMove : MonoBehaviour
{
    public float speed = 5f;
    public float force = 10f;
    private Transform player;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 direccion = (player.position - transform.position).normalized;

            rb.velocity = direccion * speed;

            rb.AddForce(direccion * force, ForceMode2D.Force);
        }
    }
}
