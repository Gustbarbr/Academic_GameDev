using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public KeyCode moveLeft = KeyCode.A;      //UP
    public KeyCode moveRight = KeyCode.D; 
    public float speed = 10.0f;            
    private float boundX = 8.9f;           
    private Rigidbody2D rb2d;        
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;                
        if (Input.GetKey(moveLeft)) {             
            vel.x = -speed;
        }
        else if (Input.GetKey(moveRight)) {      
            vel.x = speed;                    
        }
        else {
            vel.x = 0;                          
        }
        rb2d.velocity = vel;                    

        var pos = transform.position;           
        if (pos.x > boundX) {                  
            pos.x = boundX;                     
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;                    
        }
        transform.position = pos;  
        
    }
}
