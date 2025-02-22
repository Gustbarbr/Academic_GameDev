using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0;
    public static int PlayerLife = 3;
    public GUISkin layout;
    GameObject theBall;
    GameObject player;

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
