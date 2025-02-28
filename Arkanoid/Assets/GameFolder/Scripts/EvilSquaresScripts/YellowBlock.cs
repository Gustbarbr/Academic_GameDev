using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBlock : MonoBehaviour
{

    public float hp = 3;

    private ScoreManager scoreManager;

    void Start(){
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        if(hp <= 0)
        {
            scoreManager.ScoreYellowBlock();
            // Destrói o objeto quando ocorrer a colisão
            Destroy(gameObject);
        }
    }

    // Ao receber hit da bolinha, ele toma 1 de dano
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp -=1;
    }
}
