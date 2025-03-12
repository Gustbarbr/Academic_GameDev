using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 4.5f;

    private ScoreManager scoreManager;
    public bool isPlayerProjectile = false;

    public PlayerController player;

    void Start(){
        scoreManager = FindObjectOfType<ScoreManager>();
        player = FindObjectOfType<PlayerController>();
    }
    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isPlayerProjectile && collider.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject); // Destroi o inimigo
            Destroy(gameObject); // Destroi a bala ao colidir com o inimigo
            scoreManager.ScorePointos();
        }

        else if (isPlayerProjectile && collider.CompareTag("Mothershipsons"))
        {
            Destroy(collider.gameObject); // Destroi o inimigo
            Destroy(gameObject); // Destroi a bala ao colidir com o inimigo
            scoreManager.MothershipScore();
        }

        else if(!isPlayerProjectile && collider.CompareTag("Player")){
            Destroy(gameObject); // Destroi a bala ao colidir com o inimigo
            player.hp -= 1;
            player.SpacerHealth();
            if(player.hp <= 0)
            {
                //TESTE PARA TROCAR DE CENA AO MORRER
                Destroy(collider.gameObject); // Destroi o player
                Destroy(scoreManager.gameObject);
                SceneManager.LoadScene("CenaMorte");
            }
        }

        if (collider.CompareTag("TheWall"))
        {
            Destroy(gameObject);
        }
    }
}
