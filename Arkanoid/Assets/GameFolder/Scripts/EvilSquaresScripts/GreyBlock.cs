using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destrói o objeto quando ocorrer a colisão
        Destroy(gameObject);
    }


}
