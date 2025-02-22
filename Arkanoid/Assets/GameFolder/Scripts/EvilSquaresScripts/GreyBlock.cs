using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyBlock : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Desativa o objeto no qual esse script está anexado para que ele desaparessa, mas ainda pode ser regenerado
        gameObject.SetActive(false);
        Debug.Log($"{gameObject.name} foi desativado");
    }
}
