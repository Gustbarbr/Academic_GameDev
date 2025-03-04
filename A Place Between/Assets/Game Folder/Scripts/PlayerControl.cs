using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Movimentação
    [HideInInspector]
    public float movementSpeed = 5f;
    Rigidbody2D rb;

    // Variável para capturar o objeto "Lantern"
    public Transform lantern;

    // Ataque
    public Rigidbody2D bulletPrefab;
    public float attackSpeed = 0.3f;
    float attackCooldown = 0.5f;
    public float attackTimer;
    public float projectileSpeed = 300f;

    void Start()
    {
        // Guarda o componente RigidBody2D na variável
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Captura a posição do mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (new Vector2(mousePosition.x, mousePosition.y) - (Vector2)transform.position).normalized;

        // Atualiza a lanterna para apontar para a direção do mouse
        lantern.up = direction;

        // Movimenta o jogador
        MovePlayer();

        // Define o botão de ataque
        bool fire = Input.GetKey(KeyCode.Mouse0);

        // Atualiza o temporizador de ataque
        attackTimer += Time.deltaTime;

        // Se o botão for pressionado e o tempo de recarga já passou, chama a função de disparo
        if (fire && attackTimer >= attackCooldown)
        {
            Fire();
        }
    }

    void MovePlayer()
    {
        // Guarda os valores de entrada horizontal e vertical
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * movementSpeed;
        float verticalMovement = Input.GetAxisRaw("Vertical") * movementSpeed;

        // Define a velocidade do jogador
        rb.velocity = new Vector2(horizontalMovement, verticalMovement);
    }

    void Fire()
    {
        // Instancia a bala na posição do jogador (transform.position)
        Rigidbody2D bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Rigidbody2D;

        // Obtém a posição do mouse no mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcula a direção entre o jogador e o mouse
        Vector2 fireDirection = (new Vector2(mousePosition.x, mousePosition.y) - (Vector2)transform.position).normalized;

        // Ajusta a velocidade diretamente na direção do mouse
        bullet.velocity = fireDirection * projectileSpeed;  // Movimenta a bala com a velocidade máxima na direção do mouse

        // Reseta o tempo de recarga do ataque
        attackTimer = 0;
    }
}
