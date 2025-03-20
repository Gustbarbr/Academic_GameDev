using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        playerMovement();
    }

    void playerMovement(){
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2 (horizontalMovement * moveSpeed, transform.position.y);
    }
}
