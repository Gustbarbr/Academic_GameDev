using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    int score = 0;

    void Start()
    {
        score = 0;
        DontDestroyOnLoad(gameObject);
        scoreText.text = "GOTICULUS COLETADOS: " + score.ToString();
    }

    public void ScorePoints()
    {
        score += 1;
        scoreText.text = "GOTICULUS COLETADOS: " + score.ToString();
    }
}
