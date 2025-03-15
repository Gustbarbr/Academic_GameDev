using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{

    Transform player;
    public Transform skin;

    public AudioSource audioSource;
    public AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            audioSource.PlayOneShot(clip);

            skin.GetComponent<Animator>().Play("Stuck", -1);

            // Centraliza o player com a armadilha
            collision.transform.position = transform.position;

            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            // Desativa a animação de corrida do player
            collision.GetComponent<PlayerController>().skin.GetComponent<Animator>().SetBool("PlayerRun", false);

            // Força o player a entrar na animação de idle
            collision.GetComponent<PlayerController>().skin.GetComponent<Animator>().Play("PlayerIdle", -1);

            // Guarda o próprio player (collision.transform) dentro da variável player
            collision.GetComponent<PlayerController>().enabled = false;

            player = collision.transform;

            // Desabilita o box collider após a armadilha ser ativada
            GetComponent<BoxCollider2D>().enabled = false;

            // A função invoke é melhor que o contador, no caso ela roda uma função (no caso ReleasePlayer) após um certo tempo definido (no caso 1 segundo).
            Invoke("ReleasePlayer", 1.5f);
            Invoke("ResetTrap", 10);
        }
    }
    void ReleasePlayer()
    {
        player.GetComponent<PlayerController>().enabled = true;
    }

    void ResetTrap()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        skin.GetComponent<Animator>().Play("Unstuck", -1);
    }
}
