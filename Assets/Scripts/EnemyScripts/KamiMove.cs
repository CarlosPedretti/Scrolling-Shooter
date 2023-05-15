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
            Vector2 direction = (player.position - transform.position).normalized;

            rb.velocity = direction * speed;

            rb.AddForce(direction * force, ForceMode2D.Force);


            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
