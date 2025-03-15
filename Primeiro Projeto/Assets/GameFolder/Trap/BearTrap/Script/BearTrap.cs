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

            // Desativa a anima��o de corrida do player
            collision.GetComponent<PlayerController>().skin.GetComponent<Animator>().SetBool("PlayerRun", false);

            // For�a o player a entrar na anima��o de idle
            collision.GetComponent<PlayerController>().skin.GetComponent<Animator>().Play("PlayerIdle", -1);

            // Guarda o pr�prio player (collision.transform) dentro da vari�vel player
            collision.GetComponent<PlayerController>().enabled = false;

            player = collision.transform;

            // Desabilita o box collider ap�s a armadilha ser ativada
            GetComponent<BoxCollider2D>().enabled = false;

            // A fun��o invoke � melhor que o contador, no caso ela roda uma fun��o (no caso ReleasePlayer) ap�s um certo tempo definido (no caso 1 segundo).
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
