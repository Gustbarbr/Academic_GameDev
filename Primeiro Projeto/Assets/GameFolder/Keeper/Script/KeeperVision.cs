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
            // Já cria dirreto o transform e permite capturar informações do objeto pai (no caso a skin) sem intermédio de uma variável
            transform.parent.GetComponent<Animator>().Play("KeeperAttack", -1);
        }
    }
}
