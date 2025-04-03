using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float startPos, length;
    public float parallaxSpeed = 2f;  // Velocidade de movimento do parallax (ajuste conforme necessário)

    // Referência ao segundo fundo
    public GameObject secondBackground;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Movimento contínuo da câmera para a esquerda, criando o efeito de parallax.
        transform.position = new Vector3(transform.position.x - parallaxSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        secondBackground.transform.position = new Vector3(secondBackground.transform.position.x - parallaxSpeed * Time.deltaTime, secondBackground.transform.position.y, secondBackground.transform.position.z);

        // Reposiciona o fundo 1 quando ele sai da tela (do lado esquerdo)
        if (transform.position.x < startPos - length)
        {
            transform.position = new Vector3(transform.position.x + length * 2, transform.position.y, transform.position.z);
        }

        // Reposiciona o fundo 2 quando ele sai da tela (do lado esquerdo)
        if (secondBackground.transform.position.x < startPos - length)
        {
            secondBackground.transform.position = new Vector3(secondBackground.transform.position.x + length * 2, secondBackground.transform.position.y, secondBackground.transform.position.z);
        }
    }
}
