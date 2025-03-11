using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderProjectile : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do proj�til
    private float fireRate = 75f; // Taxa de disparo
    private float projectileSpeed = 10f; // Velocidade do proj�til

    public float nextFireTime = 0f;
    private float individualFire;

    private void Start()
    {
        // Faz uma taxa de disparos diferente para cada objeto
        individualFire = Random.Range(0f, fireRate);
    }

    void Update()
    {
        nextFireTime += Time.deltaTime;

        // Verifica se � hora de disparar
        if (nextFireTime >= individualFire)
        {
            ShootProjectile();
            nextFireTime = 0f; // Reinicia o tempo de disparo
            individualFire = Random.Range(0f, fireRate);
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