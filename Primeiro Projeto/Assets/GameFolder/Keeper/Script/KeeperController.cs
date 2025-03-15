using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperController : MonoBehaviour
{

    public Transform A;
    public Transform B;

    public AudioSource audioSource;
    public AudioClip keeperDieSound;

    public Transform keeperVision;

    public Transform skin;

    public bool goRight;

    void Update()
    {
        if(GetComponent<Character>().life <= 0)
        {
            audioSource.PlayOneShot(keeperDieSound);
            keeperVision.GetComponent<CircleCollider2D>().enabled = false;
            // Quando o keeper morre o colisor � desativado, permitindo que o jogador o atravesse
            GetComponent<CapsuleCollider2D>().enabled = false;
            /*// Quando o keeper morre o rigidbody � desativado, impedindo que ele atravesse o ch�o (removido para que os keepers possam atravessar uns aos outros)
            GetComponent<Rigidbody2D>().simulated = false;*/
            this.enabled = false;
        }
        // Se a anima��o atual do animator for attack, ent�o o keeper n�o andar�
        if (skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("KeeperAttack"))
        {
            // Pausa o c�digo, fazendo com que ele volte ao �nicio do "if"
            return;
        }

        if (goRight == true)
        {
            // Acessa a escala da skin para definir para onde o keeper olhar�, x = 1 significa direita
            skin.localScale = new Vector3(1, 1, 1);
            // Evitar que o keeper ultrapasse o centro do ponto A, impedindo com que ele avance infinitamente
            if(Vector2.Distance(transform.position, B.position) < 1f)
            {
                goRight = false;
            }
            // Faz o keeper andar at� a posi��o do objeto A
            // Retorna o c�lculo de movimento para o pr�prio keeper
            transform.position = Vector3.MoveTowards(transform.position, B.position, 2f * Time.deltaTime);
        }
        else
        {
            // Acessa a escala da skin para definir para onde o keeper olhar�, x = -1 significa esquerda
            skin.localScale = new Vector3(-1, 1, 1);
            // Evitar que o keeper ultrapasse o centro do ponto B, impedindo com que ele avance infinitamente
            if (Vector2.Distance(transform.position, A.position) < 1f)
            {
                goRight = true;
            }

            // Faz o keeper andar at� a posi��o do objeto B
            // Retorna o c�lculo de movimento para o pr�prio keeper
            transform.position = Vector3.MoveTowards(transform.position, A.position, 1.5f * Time.deltaTime);
        }
        
    }
}
