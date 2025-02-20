using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    float boundX = 11f;
    float boundY = 4.5f;

    public GameObject Target;

    public AudioSource source;
    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;

        // Limita até onde o player pode ir
        if (pos.x > boundX)
        {
            pos.x = boundX;
        }

        else if (pos.x < -boundX)
        {
            pos.x = -boundX;
        }

        // Limitar para não invadir o campo do player (se remover ele faz gol contra)
        else if (pos.y > boundY)
        {
            pos.y = boundY;
        }

        else if (pos.y < 0.4f)
        {
            pos.y = 0.4f;
        }

        else if(Target.transform.position.y > 0.4f && pos != Target.transform.position)
        {
            pos = Vector2.MoveTowards(transform.position, Target.transform.position, 10 * Time.deltaTime);
        }

        else
        {
            pos = Vector2.MoveTowards(transform.position, new Vector2(0, 4f), 3 * Time.deltaTime);
        }


        transform.position = pos;
    }

    void ResetEnemy()
    {
        rigidBody2D.velocity = Vector2.zero;
        transform.position = new Vector2(0, 4f);
    }

    void RestartGame()
    {
        ResetEnemy();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        source.Play();
    }
}

