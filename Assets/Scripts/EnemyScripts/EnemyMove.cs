using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5f;
    public float amplitude = 3f;
    public float frecuency = 2f;

    private Rigidbody2D rb;
    private Vector2 InitialPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitialPosition = rb.position;
    }

    private void FixedUpdate()
    {

        float verticalMovement = Mathf.Sin(Time.time * frecuency) * amplitude;


        Vector2 newPosition = InitialPosition + new Vector2(0f, -speed * Time.fixedDeltaTime) + new Vector2(0f, verticalMovement);


        rb.MovePosition(newPosition);
    }
}


