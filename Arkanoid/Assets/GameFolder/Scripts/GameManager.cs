using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

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

    public void ResetBlocks()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        ResetBlueBlock();
        ResetGreenBlock();
        ResetYellowBlock();
        ResetRedBlock();
        ResetPurpleBlock();
    }

    public void ResetBlueBlock()
    {
        // Basicamente pega uma lista com todos objetos que possuam o script BlueBlock
        BlueBlock[] blueBlocks = Object.FindObjectsByType<BlueBlock>(FindObjectsSortMode.None);  

        // Para cada objeto que tenha o script, "revive" o bloco
        foreach (BlueBlock block in blueBlocks)
        {
            block.hp = 2;
        }
    }

    // São iguais ao blue
    public void ResetGreenBlock()
    {
        GreenBlock[] greenBlocks = Object.FindObjectsByType<GreenBlock>(FindObjectsSortMode.None);  

        foreach (GreenBlock block in greenBlocks)
        {
            block.hp = 2;
        }
    }

    public void ResetYellowBlock()
    {
        YellowBlock[] yellowBlocks = Object.FindObjectsByType<YellowBlock>(FindObjectsSortMode.None);  

        foreach (YellowBlock block in yellowBlocks)
        {
            block.hp = 3;
        }
    }

    public void ResetRedBlock()
    {
        RedBlock[] redBlocks = Object.FindObjectsByType<RedBlock>(FindObjectsSortMode.None);  

        foreach (RedBlock block in redBlocks)
        {
            block.hp = 3;
        }
    }

    public void ResetPurpleBlock()
    {
        PurpleBlock[] purpleBlocks = Object.FindObjectsByType<PurpleBlock>(FindObjectsSortMode.None);  

        foreach (PurpleBlock block in purpleBlocks)
        {
            block.hp = 4;
        }
    }
}
