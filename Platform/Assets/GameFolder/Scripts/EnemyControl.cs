using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public GameObject goTo_A;
    public GameObject goTo_B;
    private int lifePlayer = 0;

    private bool movingToB = true; // Para controlar para qual ponto o inimigo vai

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = goTo_A.transform.position; // Come�a na posi��o de goTo_A
    }

    void Update()
    {
        // Verifica qual ponto o inimigo est� indo
        GameObject target = movingToB ? goTo_B : goTo_A;

        // Move o inimigo para o alvo
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        // Se o inimigo chegou no alvo, troca o destino
        if (Vector2.Distance(transform.position, target.transform.position) <= 0.2f)
        {
            movingToB = !movingToB; // Alterna entre ir para A ou B
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            lifePlayer++;
            if(lifePlayer >= 3){
                SceneManager.LoadScene("CenaMorte");
            }
        }
    }

}
