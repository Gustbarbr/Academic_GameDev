using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;


public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    float boundX = 3.85f; 
    float boundY = 4.5f; 

    // Start is called before the first frame update
    public AudioSource source;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = mousePos.x;
        pos.y = mousePos.y;

        // Limita até onde o player pode ir
        if (pos.x > boundX)
        {
            pos.x = boundX;
        }

        else if (pos.x < -boundX)
        {
            pos.x = -boundX;
        }

        // Limitar o meio da "quadra" (esqueci o nome) para que o player não avance ao campo inimigo
        else if (pos.y > -0.4f)
        {
            pos.y = -0.4f;
        }

        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }

        transform.position = pos;
    }

    void ResetPlayer()
    {
        rigidBody2D.velocity = Vector2.zero;
        transform.position = new Vector2(0, -4f);
    }

    void RestartGame()
    {
        ResetPlayer();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        source.Play();
    }

}
