using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    private float boundY = 3.4f;
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rigidbody.velocity;
        if (Input.GetKey(KeyCode.S))
        {
            vel.y = -speed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            vel.y = speed;
        }
        else
        {
            vel.y = 0;
        }
        rigidbody.velocity = vel;

        // Limita a posição do jogador na tela
        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}
