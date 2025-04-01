using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Collectibles : MonoBehaviour
{
    private ScoreManager score;

    private void Start()
    {
        score = FindObjectOfType<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            score.ScorePoints();
            Destroy(gameObject);
        }
    }

}
