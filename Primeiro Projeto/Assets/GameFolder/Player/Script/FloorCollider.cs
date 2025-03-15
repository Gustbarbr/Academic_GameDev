using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    public bool canJump;

    public AudioSource audioSource;
    public AudioClip groundedSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            canJump = true;
            audioSource.PlayOneShot(groundedSound, 0.75f);
        }
    }
}
