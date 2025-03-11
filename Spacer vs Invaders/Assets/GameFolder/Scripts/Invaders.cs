using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Invaders : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float descentTimer = 0.0f; 
    public float descentTime = 10.0f; 
    private int state = 0;
    private float x;
    private float speed = 2.0f;
    private float descentSpeed = 1.0f; 
    PlayerController player;
    ScoreManager scoreManager;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        scoreManager = FindObjectOfType<ScoreManager>();
        rb2d = GetComponent<Rigidbody2D>();  
        x = transform.position.x;

        var vel = rb2d.velocity;
        vel.x = speed;
        rb2d.velocity = vel;
    }

    void Update()
    {
        if(transform.position.y <= -3f){
            Destroy(player.gameObject);
            Destroy(scoreManager.gameObject);
            SceneManager.LoadScene("CenaMorte");
        }

        timer += Time.deltaTime;
        descentTimer += Time.deltaTime;

        if (timer >= waitTime)
        {
            ChangeState();
            timer = 0.0f;
        }

        if (descentTimer >= descentTime)
        {
            Descer();
            descentTimer = 0.0f;
        }
    }

    void ChangeState()
    {
        var vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
    }

    void Descer()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - descentSpeed);
        descentTime -= 1.5f;
    }
}
