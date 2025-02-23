using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public KeyCode moveLeft = KeyCode.A;      //UP
    public KeyCode moveRight = KeyCode.D; 
    public float speed = 10.0f;            
    private float boundX = 9.3f;           
    private Rigidbody2D rb2d;
    public int playerHP = 3;

    public GameObject gameManager;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }

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
        
        if(playerHP <= 0)
        {
            ResetPlayer();
            ResetBlocks();
            playerHP = 3;
        }
    }

    void ResetBlocks()
    {
        GameManager gm = gameManager.GetComponent<GameManager>();
        gm.ResetGreyBlock();
        gm.ResetBlueBlock();
    }

    public void ResetPlayer()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector2(0f, -4f);
    }
}
