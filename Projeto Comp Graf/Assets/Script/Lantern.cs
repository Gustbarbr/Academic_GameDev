using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public Transform player; // Referência ao player

    void Start()
    {
        // Faz o objeto ser filho do player
        transform.parent = player; 
        
        // Ajusta a posição se necessário
        transform.localPosition = new Vector3(0, 1.5f, 0); // Ajuste conforme necessário
        transform.localRotation = Quaternion.identity; // Mantém a rotação inicial
    }
}
