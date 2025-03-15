using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResizer : MonoBehaviour
{

    bool flag = true; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(flag == true){
                // Obtém a escala atual do player
                Vector3 currentScale = other.transform.localScale;

                // Muda somente a altura, mantendo largura e profundidade iguais
                other.transform.localScale = new Vector3(currentScale.x, 10f, currentScale.z);

                flag = false;
            }

            else{
                // Obtém a escala atual do player
                Vector3 currentScale = other.transform.localScale;

                // Muda somente a altura, mantendo largura e profundidade iguais
                other.transform.localScale = new Vector3(currentScale.x, 1f, currentScale.z);

                flag = true;
            }
            
        }
    }
}
