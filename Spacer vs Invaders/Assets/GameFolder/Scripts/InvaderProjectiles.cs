using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderProjectile : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do proj�til
    public float fireRate = 0f; // Taxa de disparo
    public float projectileSpeed = 5f; // Velocidade do proj�til

    private float nextFireTime = 0f;

    void Update()
    {
        nextFireTime += Time.deltaTime;

        // Verifica se � hora de disparar
        if (nextFireTime >= fireRate)
        {
            ShootProjectile();
            nextFireTime = 0; // Reinicia o tempo de disparo
        }
    }

    void ShootProjectile()
    {
        // Cria uma inst�ncia do proj�til na posi��o do invasor
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Adiciona uma for�a ao proj�til para mov�-lo para baixo
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        
        // Define a velocidade do proj�til para baixo
        rb.velocity = Vector2.down * projectileSpeed; // Move para baixo
    }
}