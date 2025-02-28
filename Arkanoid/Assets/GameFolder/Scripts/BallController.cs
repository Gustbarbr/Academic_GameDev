using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public GameObject player;
    private float boundX = 10f;

    private LifeManager lifeManager;


    // Start is called before the first frame update
    void Start()
    {

        Scene cenaAtual = SceneManager.GetActiveScene();
        string nomeCena = cenaAtual.name;

        // Garantir que só haja um ball na cena
        if (FindObjectsOfType<PlayerController>().Length > 1)
        {
            Destroy(gameObject);  // Se já existe uma instância do jogador, destrua este
        }

        if(nomeCena == "Cena1" || nomeCena == "Cena2"){
            DontDestroyOnLoad(gameObject);  // Faz o objeto não ser destruído
        }

        rb2d = GetComponent<Rigidbody2D>(); 
        lifeManager = FindObjectOfType<LifeManager>();
        Invoke("GoBall", 2);          
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void GoBall(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(20, -15));
        } else {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }
    void OnCollisionEnter2D (Collision2D coll) {
            if(coll.collider.CompareTag("Player")){
                Vector2 vel;
                vel.x = rb2d.velocity.x;
                vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
                rb2d.velocity = vel;
                Vector2 collisionDirection = (transform.position - coll.transform.position).normalized;

                // Aumenta a força com base na direção da colisão
                float forceMagnitude = 0.1f; // Ajuste conforme necessário para aumentar a intensidade
                rb2d.AddForce(collisionDirection * forceMagnitude, ForceMode2D.Impulse); // Aplica força na direção da colisão
        }

            if(coll.collider.name == "bottom")
            {
                lifeManager.LoseLife();
                // Acessa um outro script
                PlayerController playerController = player.GetComponent<PlayerController>();
                // Acessa uma vari�vel p�blica do outro script
                int playerLife = playerController.playerHP;
                // Causa dano
                playerController.playerHP--;
                RestartGame();
            }
    }
    public void ResetBall(){
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector2(0f, 0f);
    }
    void RestartGame(){
        // Acessa um outro script
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.ResetPlayer();
        ResetBall();
        Invoke("GoBall", 1);
    }


}
