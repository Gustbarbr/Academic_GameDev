using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderProjectile : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do projétil
    public float fireRate = 0f; // Taxa de disparo
    public float projectileSpeed = 5f; // Velocidade do projétil

    private float nextFireTime = 0f;

    void Update()
    {
        nextFireTime += Time.deltaTime;

        // Verifica se é hora de disparar
        if (nextFireTime >= fireRate)
        {
            ShootProjectile();
            nextFireTime = 0; // Reinicia o tempo de disparo
        }
    }

    void ShootProjectile()
    {
        // Cria uma instância do projétil na posição do invasor
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Adiciona uma força ao projétil para movê-lo para baixo
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        
        // Define a velocidade do projétil para baixo
        rb.velocity = Vector2.down * projectileSpeed; // Move para baixo
    }
}