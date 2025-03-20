using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private float boundY = 3.4f;
    private float boundX = 4f;
    private Rigidbody2D rigidbody;

    public GameObject laser;
    public float hp = 3;
    private float nextFireTime = 0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var vel = rigidbody.velocity;

        // Movimento vertical
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

        // Movimento horizontal 
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            vel.x = -speed;
        }
        else{
            vel.x = 0;
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

        if (pos.x > boundX)
        {
            pos.x = boundX;
        }
        else if (pos.x < -boundX)
        {
            pos.x = -boundX;
        }
        transform.position = pos;

        nextFireTime += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && nextFireTime >= 0.3f)
        {
            ShootLaser();
            nextFireTime = 0f;
        }
    }

    void ShootLaser()
    {
        // Instancia o laser na posição do jogador
        GameObject laserProjectile = Instantiate(laser, transform.position, Quaternion.identity);

        // Obtém o Rigidbody2D do laser e aplica uma força para movê-lo
        Rigidbody2D rb = laserProjectile.GetComponent<Rigidbody2D>();

        // Adiciona uma velocidade para o laser
        rb.velocity = new Vector2(10f, 0f);
    }
}
