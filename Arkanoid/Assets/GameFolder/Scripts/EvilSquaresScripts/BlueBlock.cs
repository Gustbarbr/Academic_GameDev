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
            // Desativa o objeto no qual esse script está anexado para que ele desaparessa, mas ainda pode ser regenerado
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<BlueBlock>().enabled = false;
        }
        
    }

    // Ao receber hit da bolinha, ele toma 1 de dano
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp -=1;
    }
}
