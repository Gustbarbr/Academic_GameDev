using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform targetPlayer; // Guarda o player para persegui-lo
    public float speed; // Guarda um dos multilicadores de velocidade
    public float detectionRange; // Alcance de deteccao para iniciar a perseguicao

    public float hp = 10f;

    void Update()
    {
        // Guarda a distancia entre o inimigo e o player
        float distance = Vector3.Distance(transform.position, targetPlayer.position);

        // Se a distancia entre ambos for menor ou igual a deteccao, entao o inimigo persegue o player
        if(distance <= detectionRange)
        {
            // Define sua velocidade
            float velocity = speed * Time.deltaTime;

            // Faz o inimigo perseguir o player, usando sua posicao e a posicao do player como base
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, velocity);
        }
    }
}
