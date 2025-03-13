using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float lenght;
    private float movingSpeed = 5f;
    public float parallaxEffect;

    void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    //PARALLAX DOIDO DEMAISSSSSXXXXXXXX;
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * movingSpeed * parallaxEffect;
        if(transform.position.x < -lenght ) {
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
        }
    }
}
