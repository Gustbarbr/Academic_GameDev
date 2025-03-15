using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }private void OnTriggerEnter2D(Collider2D collision)
    {
        // Toda vez que colide com algo com tag de inimigo, ele tomará dano
        if (collision.CompareTag("Enemy"))
        {
            // Se o combo for 1 o inimigo toma 1 de dano
            if(player.GetComponent<PlayerController>().comboCount == 1)
            {
                collision.GetComponent<Character>().life--;
            }
            // Se o combo for 2 o inimigo toma 2 de dano
            if (player.GetComponent<PlayerController>().comboCount == 2)
            {
                collision.GetComponent<Character>().life -= 2;
            }
        }
    }
}
