using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int PlayerScore = 0; 
    public static int PlayerLife = 3; 
    public GUISkin layout;              
    GameObject theBall; 

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Score (string wallID) {
        if (wallID == "bottom")
        {
            PlayerLife--;
        } 
    }

}
