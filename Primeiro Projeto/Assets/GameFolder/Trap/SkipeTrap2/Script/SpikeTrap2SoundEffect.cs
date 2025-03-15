using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap2SoundEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }
}
