using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void ResetGreyBlock()
    {
        // Basicamente pega uma lista com objetos que possuam o script "GreyBlock" anexado a eles, usando o novo método recomendado para Unity 2023
        GreyBlock[] greyBlocks = Object.FindObjectsByType<GreyBlock>(FindObjectsSortMode.None);

        // Para cada objeto que possua o script ele chamará uma função, que no caso "revive" o bloco
        foreach (GreyBlock block in greyBlocks)
        {
            block.GetComponent<SpriteRenderer>().enabled = true;
            block.GetComponent<BoxCollider2D>().enabled = true;
            block.GetComponent<GreyBlock>().enabled = true;
        }
    }

    public void ResetBlueBlock()
    {
        // Basicamente pega uma lista com objetos que possuam o script "BlueBlock" anexado a eles, usando o novo método recomendado para Unity 2023
        BlueBlock[] blueBlocks = Object.FindObjectsByType<BlueBlock>(FindObjectsSortMode.None);

        // Para cada objeto que possua o script ele chamará uma função, que no caso "revive" o bloco
        foreach (BlueBlock block in blueBlocks)
        {
            block.GetComponent<SpriteRenderer>().enabled = true;
            block.GetComponent<BoxCollider2D>().enabled = true;
            block.GetComponent<BlueBlock>().enabled = true;
            block.hp = 2;
        }
    }
}
