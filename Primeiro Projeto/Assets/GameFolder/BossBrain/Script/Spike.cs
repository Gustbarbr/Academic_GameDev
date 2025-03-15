using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    Transform boss;

    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            boss = collision.transform;

            collision.GetComponent<BossController>().enabled = false;
            // Permite que o spike arraste o chefe para cima
            collision.transform.parent = transform;

            // Centraliza o chefe no spike
            collision.transform.localPosition = Vector3.zero;
        }
    }

    public void CollisionSound()
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }

    public void ReleaseBoss()
    {
        if (boss != null)
        {
            boss.GetComponent<BossController>().enabled = true;
            // Separa o chefe e o spike
            boss.parent = null;
        }
    }
}
