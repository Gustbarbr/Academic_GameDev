using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Player movement variables
    public float speed = 10.0f;
    private float boundX = 10.5f;
    private Rigidbody2D rigidbody;

    // Shooting variables
    public GameObject projectilePrefab;
    public float fireRate = 0.5f; // Tempo de recarga
    public float projectileSpeed = 10f; // Velocidade do projétil
    public float nextFireTime = 0f;
    public TextMeshProUGUI scoreText;
    public float hp = 3;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        scoreText.text = "LIFE: " + hp.ToString();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // Player movement
        var vel = rigidbody.velocity;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = speed;
        }
        else
        {
            vel.x = 0;
        }
        rigidbody.velocity = vel;

        // Limita a posição do jogador na tela
        var pos = transform.position;
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
        // Verifica se o botão de espaço foi pressionado e o tempo adequado para disparar
        if (Input.GetKeyDown(KeyCode.Space) && nextFireTime >= 0.5f)
        {
            ShootProjectile();
            nextFireTime = 0;  // Atualiza o tempo para o próximo disparo
        }
    }

    void ShootProjectile()
    {
        // Cria uma instância do projétil na posição do jogador
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Adiciona uma força ao projétil para movê-lo para frente
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        
        // Define a velocidade do projétil
        rb.velocity = transform.up * projectileSpeed;  // Vai para a direção 'up' do jogador

        // Define que este projétil é do jogador
        projectile.GetComponent<ProjectileBehaviour>().isPlayerProjectile = true; 
    }

    public void SpacerHealth(){
        scoreText.text = "LIFE: " + hp.ToString();
    }
}
