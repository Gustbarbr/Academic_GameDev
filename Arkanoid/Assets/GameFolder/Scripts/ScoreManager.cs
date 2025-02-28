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
        DontDestroyOnLoad(gameObject);
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void ScoreGreyBlock(){
        score+=5;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void ScoreBlueBlock(){
        score+=10;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void ScoreGreenBlock(){
        score+=25;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void ScoreYellowBlock(){
        score+=35;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void ScoreRedBlock(){
        score+=50;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void ScorePurpleBlock(){
        score+=100;
        scoreText.text = "SCORE: " + score.ToString();
    }
}
