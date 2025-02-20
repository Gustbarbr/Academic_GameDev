using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Player = 0;
    public static int Enemy = 0;

    public GUISkin layout;
    GameObject theBall;
    GameObject thePlayer;
    GameObject anEnemy;


    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        anEnemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public static void Score (string wallID)
    {
        if(wallID == "up")
        {
            Player++;
        }
        else
        {
            Enemy++;
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + Player);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + Enemy);

        if(GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            Player = 0;
            Enemy = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
            thePlayer.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
            anEnemy.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        else if(Player == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER WINS");
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
            thePlayer.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
            anEnemy.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        else if (Enemy == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "ENEMY WINS");
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
            thePlayer.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
            anEnemy.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }
}
