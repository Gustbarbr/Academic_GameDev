using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyBlock : MonoBehaviour
{

    private ScoreManager scoreManager;

    void Start(){
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        scoreManager.ScoreGreyBlock();
        // Destrói o objeto quando ocorrer a colisão
        Destroy(gameObject);
    }


}
