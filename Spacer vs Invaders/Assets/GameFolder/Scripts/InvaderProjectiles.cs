using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderProjectile : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do projétil
    private float fireRate = 75f; // Taxa de disparo
    private float projectileSpeed = 10f; // Velocidade do projétil

    public float nextFireTime = 0f;
    private float individualFire;

    private void Start()
    {
        // Faz uma taxa de disparos diferente para cada objeto
        individualFire = Random.Range(0f, fireRate);
    }

    void Update()
    {
        int randomNumber = Random.Range(0, 10);
        nextFireTime += Time.deltaTime;

        // Verifica se é hora de disparar
        if (nextFireTime >= individualFire)
        {
            ShootProjectile();
            nextFireTime = 0f; // Reinicia o tempo de disparo
            individualFire = Random.Range(0f, fireRate);
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