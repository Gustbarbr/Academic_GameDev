using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour
{

    public float hp = 2;

    private void Update()
    {
        if(hp <= 0)
        {
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
