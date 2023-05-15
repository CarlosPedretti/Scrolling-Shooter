using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 5f;
    private float LeftLimit;
    private float RightLimit;
    private int direction = 1;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LeftLimit = transform.position.x - distance / 2f;
        RightLimit = transform.position.x + distance / 2f;
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(speed * direction, rb.velocity.y);


        if (direction == 1 && transform.position.x >= RightLimit)
        {
            ChangeDirection(-1);
        }
        else if (direction == -1 && transform.position.x <= LeftLimit)
        {
            ChangeDirection(1);
        }
    }

    private void ChangeDirection(int newDirection)
    {
        direction = newDirection;
    }
}
