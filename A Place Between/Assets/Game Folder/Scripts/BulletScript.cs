using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    float lifetime = 1f;


    void Start()
    {
        // Apos certo tempo, a bala eh destruida
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
