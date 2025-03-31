using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator animator;

    public float moveSpeed;
    public float jumpForce;
    float buttonPressingTime = 0.3f;
    float jumpTime;
    bool jump;
    bool isGrounded;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        playerMovement();
        playerJump();
    }

    void playerMovement(){
        // Armazena o valor da movimentação através das teclas direcionais
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        // Aplica a velocidade no rigidbody a partir da multiplicação entre o input horizontal e o valor da movespeed
        rb.velocity = new Vector2 (horizontalMovement * moveSpeed, rb.velocity.y);

        // Basicamente é só para ativar a animação de andar (animator) e mudar a direção que ele está olhando
        if(horizontalMovement > 0){
            transform.localScale = new Vector3(1.769f, 1.769f, 1.769f);
            animator.SetFloat("Speed", 1);
        }
        else if(horizontalMovement < 0){
            transform.localScale = new Vector3(-1.769f, 1.769f, 1.769f);
            animator.SetFloat("Speed", 1);
        }

        else{
            animator.SetFloat("Speed", 0);
        }
    }

    void playerJump(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            jump = true;
            jumpTime = 0;
        }

        if (jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTime += Time.deltaTime;
            animator.SetBool("Jump", true);
        }

        if (Input.GetKeyUp(KeyCode.Space) || jumpTime > buttonPressingTime)
        {
            jump = false;
            animator.SetBool("Jump", false);
        }
    }

    // Detecta se o jogador tocou o solo
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifique se o jogador tocou o solo (pode ser necessário ajustar a tag)
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Detecta quando o jogador deixa o solo
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
