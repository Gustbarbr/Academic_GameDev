using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    void GoBall()
    {
        float rand = Random.Range(0, 2);

        if(rand < 1)
        {
            rigidBody2D.AddForce(new Vector2(0, 20));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(0, -20));
        }
    }
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 vel = rigidBody2D.velocity * 1.2f; 
        if (vel.x > 10f) vel.x = 10f; // Limita a velocidade horizontal
        if (vel.y > 10f) vel.y = 10f; // Limita a velocidade vertical
        rigidBody2D.velocity = vel; // Aplica a nova velocidade
    }

    void ResetBall()
    {
        rigidBody2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
}
