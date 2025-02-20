using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Ball")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            hitInfo.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }
}
