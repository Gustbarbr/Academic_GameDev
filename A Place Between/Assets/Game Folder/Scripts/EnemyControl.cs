using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform targetPlayer; // Guarda o player para persegui-lo
    public float speed; // Guarda um dos multi�licadores de velocidade
    public float detectionRange; // Alcance de detec��o para iniciar a persegui��o

    void Update()
    {
        // Guarda a dist�ncia entre o inimigo e o player
        float distance = Vector3.Distance(transform.position, targetPlayer.position);

        // Se a dist�ncia entre ambos for menor ou igual a detec��o, ent�o o inimigo persegue o player
        if(distance <= detectionRange)
        {
            // Define sua velocidade
            float velocity = speed * Time.deltaTime;

            // Faz o inimigo perseguir o player, usando sua posi��o e a posi��o do player como base
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, velocity);
        }
    }
}
