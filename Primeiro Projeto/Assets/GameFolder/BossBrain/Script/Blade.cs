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
        // Posi��o inicial do target
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

        // atualiza a posi��o do pr�prio objeto, movendo sua posi��o em dire��o ao targetPosition
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5 * Time.deltaTime);

        // Rotaciona a l�mina
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
