using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    private float appearRate = 15f;
    private float nextAppearTime = 0f;
    private float appearTimer;

    private Vector2 startPosition = new Vector2(13.5f, 5.3f);  // Posição de spawn no lado direito
    private Vector2 endPosition = new Vector2(-13.5f, 5.3f);   // Posição de destino no lado esquerdo
    private float moveSpeed = 2f;  // Velocidade de movimento da nave mãe

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        appearTimer = Random.Range(0f, appearRate);  // A nave pode aparecer em qualquer momento entre 0 e o valor de appearRate
    }

    void Update()
    {
        nextAppearTime += Time.deltaTime;

        // Verifica se é hora de spawn da nave mãe
        if (nextAppearTime >= appearTimer)
        {
            SpawnMothership();
            nextAppearTime = 0f; // Reinicia o tempo para a próxima nave
            appearTimer = Random.Range(0f, appearRate);  // Determina um novo tempo aleatório para o próximo spawn
        }
    }

    void SpawnMothership()
    {
        transform.position = startPosition;  // Coloca a nave na posição de spawn no lado direito

        // Inicia a movimentação da nave para o lado esquerdo
        StartCoroutine(MoveMothership());
    }

    // Corrotina para mover a nave mãe da direita para a esquerda
    IEnumerator MoveMothership()
    {
        float journeyLength = Vector2.Distance(startPosition, endPosition);
        float startTime = Time.time;

        // Enquanto a nave não atingir o destino
        while (Vector2.Distance(transform.position, endPosition) > 0.1f)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;

            // Garante que apenas a coordenada 'x' será alterada e 'y' permanecerá em 5.3
            transform.position = new Vector2(
                Mathf.Lerp(startPosition.x, endPosition.x, fractionOfJourney),
                startPosition.y
            );  // Movimenta a nave apenas no eixo X, mantendo Y constante

            yield return null;  // Espera o próximo frame
        }

        // Garante que a nave chegue exatamente ao ponto final
        transform.position = new Vector2(endPosition.x, startPosition.y);
    }
}
