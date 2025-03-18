using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float lenght;
    public float movingSpeed = 5f;  // Velocidade original
    public float parallaxEffect;

    void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    //PARALLAX DOIDO DEMAISSSSSXXXXXXXX;
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * movingSpeed * parallaxEffect;
        if(transform.position.x < -lenght ) {
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
        }
    }

    // Função para diminuir a velocidade do parallax
    public void SlowDownParallax()
    {
        movingSpeed *= 0.5f;  // Reduz a velocidade pela metade
        StartCoroutine(ResetSpeedAfterTime(5f));  // Começa a contagem de 5 segundos
    }

    // Coroutine para resetar a velocidade após um certo tempo
    private IEnumerator ResetSpeedAfterTime(float time)
    {
        yield return new WaitForSeconds(time);  // Espera pelo tempo especificado (5 segundos)
        movingSpeed *= 2f;  // Restaura a velocidade original
    }
}
