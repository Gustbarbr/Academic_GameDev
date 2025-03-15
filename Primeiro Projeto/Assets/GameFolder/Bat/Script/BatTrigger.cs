using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{
    // Criar um vetor que guarda vários objetos
    public Transform[] bat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // A cada posição do vetor um morcego terá seu scipt habilitado
            foreach(Transform obj in bat)
            {
                obj.GetComponent<BatController>().enabled = true;
                // Já acessa diretamente o player, sem precisar defini-lo manualmente
                obj.GetComponent<BatController>().player = collision.transform;
            }
        }
    }
}
