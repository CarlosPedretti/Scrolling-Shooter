using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    public float cameraSpeed;

    void Start()
    {
        
    }


    void Update()
    {
      transform.Translate (Vector3.up  * cameraSpeed * Time.deltaTime);
    }
}
