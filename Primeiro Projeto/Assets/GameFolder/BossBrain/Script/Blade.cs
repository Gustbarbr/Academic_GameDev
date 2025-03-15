using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;

    public Vector3 targetPosition;

    void Start()
    {
        // Posição inicial do target
        targetPosition = A.position; 
    }

    void Update()
    {
       if(transform.position == A.position)
       {
            targetPosition = B.position;
       }

        if (transform.position == B.position)
        {
            targetPosition = C.position;
        }

        if (transform.position == C.position)
        {
            targetPosition = D.position;
        }

        if (transform.position == D.position)
        {
            targetPosition = A.position;
        }

        // atualiza a posição do próprio objeto, movendo sua posição em direção ao targetPosition
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5 * Time.deltaTime);

        // Rotaciona a lâmina
        transform.Rotate(0, 0, -500 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1);
        }
    }
}
