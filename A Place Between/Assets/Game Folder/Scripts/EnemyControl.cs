using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform targetPlayer; // Guarda o player para persegui-lo
    public float speed; // Guarda um dos multi´licadores de velocidade
    public float detectionRange; // Alcance de detecção para iniciar a perseguição

    void Update()
    {
        // Guarda a distância entre o inimigo e o player
        float distance = Vector3.Distance(transform.position, targetPlayer.position);

        // Se a distância entre ambos for menor ou igual a detecção, então o inimigo persegue o player
        if(distance <= detectionRange)
        {
            // Define sua velocidade
            float velocity = speed * Time.deltaTime;

            // Faz o inimigo perseguir o player, usando sua posição e a posição do player como base
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, velocity);
        }
    }
}
