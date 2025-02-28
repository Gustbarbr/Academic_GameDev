using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndVideo: MonoBehaviour
{

    public VideoPlayer videoPlayer;
    float delayBeforePlay = 2f;

    private void Start()
    {
        StartCoroutine(StartVideoAfterDelay(delayBeforePlay));
    }

    IEnumerator StartVideoAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Inicia o v�deo ao apertar play
        videoPlayer.Play();

        // Ao chegar ao fim do v�deo, ele desaparesse
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        gameObject.SetActive(false);
    }
}
