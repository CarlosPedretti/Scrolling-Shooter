using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Vector2 speed = new Vector2 (20, 20);


    void Start()
    {

    }


    void Update()
    {

        float InputY = Input.GetAxis("Vertical");
        float InputX = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3 (speed.x * InputX, speed.y * InputY);

        movement *= Time.deltaTime;

        transform.Translate(movement);

    }
}
