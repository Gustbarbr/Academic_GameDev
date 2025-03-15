using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{

    public Transform A;
    public Transform B;

    public Transform skin;

    public bool goRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goRight == true)
        {
            // Acessa a escala da skin para definir para onde o ghost olhar�, x = 1 significa direita
            // Como o sprite � invertido em rela��o aos demais, ent�o o x tamb�m � invertido
            skin.localScale = new Vector3(-1, 1, 1);
            // Evitar que o ghost ultrapasse o centro do ponto A, impedindo com que ele avance infinitamente
            if (Vector2.Distance(transform.position, B.position) < 0.1f)
            {
                // Quando ficar pr�ximo do ponto B, ele ser� teletransportado de volta para o ponto A
                transform.position = A.position;
            }
            // Faz o ghost andar at� a posi��o do objeto A
            // Retorna o c�lculo de movimento para o pr�prio ghost
            transform.position = Vector3.MoveTowards(transform.position, B.position, 12f * Time.deltaTime);
        }
        else
        {
            // Acessa a escala da skin para definir para onde o ghost olhar�, x = -1 significa esquerda
            // Como o sprite � invertido em rela��o aos demais, ent�o o x tamb�m � invertido
            skin.localScale = new Vector3(1, 1, 1);
            // Evitar que o ghost ultrapasse o centro do ponto B, impedindo com que ele avance infinitamente
            if (Vector2.Distance(transform.position, A.position) < 0.1f)
            {
                // Quando ficar pr�ximo do ponto A, ele ser� teletransportado de volta para o ponto B
                transform.position = B.position;
            }

            // Faz o ghost andar at� a posi��o do objeto B
            // Retorna o c�lculo de movimento para o pr�prio ghost
            transform.position = Vector3.MoveTowards(transform.position, A.position, 12f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1);
        }
    }
}
