using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private float appearRate = 5f;
    public float nextAppearTime = 0f;
    public float appearTimer;

    private float moveSpeed = 5f;  // Velocidade de movimento da nave mãe
    private Vector2 startPosition;
    private Vector2 endPosition;
    private bool isMoving = false;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        appearTimer = Random.Range(0f, appearRate);  // A nave pode aparecer em qualquer momento entre 0 e o valor de appearRate
        startPosition = new Vector2(13.5f, transform.position.y);
        endPosition = new Vector2(-13.5f, transform.position.y);
    }

    void Update()
    {
        nextAppearTime += Time.deltaTime;

        // Verifica se é hora de spawn da nave mãe
        if (nextAppearTime >= appearTimer && !isMoving)
        {
            SpawnMothership();
            nextAppearTime = 0f; // Reinicia o tempo para a próxima nave
            appearTimer = Random.Range(0f, appearRate);  // Determina um novo tempo aleatório para o próximo spawn
        }

        // Move a nave mãe de acordo com a direção
        if (isMoving)
        {
            MoveMothership();
        }
    }

    void SpawnMothership()
    {
        transform.position = startPosition; // Coloca a nave no ponto inicial
        isMoving = true; // Inicia o movimento da nave
    }

    void MoveMothership()
    {
        // Move a nave em direção ao ponto final
        transform.position = Vector2.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);

        // Quando alcançar o ponto final, reinicia o movimento
        if (transform.position.x <= endPosition.x)
        {
            // Resetando a posição e o movimento
            transform.position = endPosition;
            isMoving = false;  // Para o movimento da nave
        }
    }
}
