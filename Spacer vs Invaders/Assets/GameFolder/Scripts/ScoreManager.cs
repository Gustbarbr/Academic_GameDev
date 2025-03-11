using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    int score = 0;

    void Start(){
        score = 0;
        DontDestroyOnLoad(gameObject);
        scoreText.text = "SPACERS POINTOS: " + score.ToString();
    }

    public void ScorePointos(){
        score+=10;
        scoreText.text = "SPACERS POINTOS: " + score.ToString();
    }
}
