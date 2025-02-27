using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    private float boundX = 10.5f;
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rigidbody.velocity;
        if(Input.GetKey(KeyCode.LeftArrow)){
            vel.x = -speed;
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            vel.x = speed;
        }
        else{
            vel.x = 0;
        }
        rigidbody.velocity = vel;

        var pos = transform.position;
        if(pos.x > boundX){
            pos.x = boundX;
        }
        else if(pos.x<-boundX){
            pos.x = -boundX;
        }
        transform.position = pos;

        //PARTE DE TIROOOOO:
        if(Input.GetKey(KeyCode.Space)){
            Debug.Log("a");
        }
    }
}
