using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{
    // Criar um vetor que guarda v�rios objetos
    public Transform[] bat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // A cada posi��o do vetor um morcego ter� seu scipt habilitado
            foreach(Transform obj in bat)
            {
                obj.GetComponent<BatController>().enabled = true;
                // J� acessa diretamente o player, sem precisar defini-lo manualmente
                obj.GetComponent<BatController>().player = collision.transform;
            }
        }
    }
}
