using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperVision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // J� cria dirreto o transform e permite capturar informa��es do objeto pai (no caso a skin) sem interm�dio de uma vari�vel
            transform.parent.GetComponent<Animator>().Play("KeeperAttack", -1);
        }
    }
}
