using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyBlock : MonoBehaviour
{

    public float hp = 1;

    void Update()
    {
        if(hp <= 0)
        {
            // Desativa o objeto no qual esse script está anexado para que ele desaparessa, mas ainda pode ser regenerado
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp--;
    }

    // Reseta o HP do bloco e reativa
    public void RegenerateGreyBlocks()
    {
        hp++;
        gameObject.SetActive(true);
    }
}
