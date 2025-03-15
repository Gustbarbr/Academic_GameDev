// Bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 vel;

    public AudioSource audioSource;
    public AudioClip attack1Sound;
    public AudioClip attack2Sound;
    public AudioClip damageSound;
    public AudioClip dashSound;

    // Public consegue pegar a variável de outro script e mostra no editor
    public Transform floorCollider;

    // Pega os componentes de transform da skin (posição, rotação, escala)
    public Transform skin;

    public Transform gameOverScreen;
    public Transform pauseGameScreen;

    public int comboCount;
    public float comboTime;

    float dashTime;

    public string currentLevel;

    // A primeira coisa que roda ao apertar play (roda uma vez)
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        currentLevel = SceneManager.GetActiveScene().name;
        // O player não é destruído ao trocar de cenas
        DontDestroyOnLoad(transform.gameObject);
        
    }

    // É um loop, enquanto o jogador estiver em cena o update será executado
    void Update()
    {
        // é um if de string com not equals
        if (!currentLevel.Equals(SceneManager.GetActiveScene().name))
        {
            currentLevel = SceneManager.GetActiveScene().name;
            // Procura a posição de spawn em outras cenas
            transform.position = GameObject.Find("Spawn").transform.position;
        }
        // Se a vida do jogar for menor ou igual a 0, esse script será desativado, impedindo que o player faça qualquer ação
        if(GetComponent<Character>().life <= 0)
        {
            gameOverScreen.GetComponent<GameOver>().enabled = true;
            rb.simulated = false;
            this.enabled = false;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            // Se o esc for pressionado ele retornará como verdade para ele mesmo, se o esc for pressionado de novo ele vai trocar para falso
            pauseGameScreen.GetComponent<Pause>().enabled = !pauseGameScreen.GetComponent<Pause>().enabled;
        }

        dashTime = dashTime + Time.deltaTime;
        // Fire2 em edit->project settings está marcado com o botão escolhido, no caso shift
        if (Input.GetButtonDown("Fire2") && dashTime >= 0.5)
        {
            // O 0.75f define o volume do áudio, sendo 1 o valor original
            audioSource.PlayOneShot(dashSound, 0.75f);

            dashTime = 0;
            skin.GetComponent<Animator>().Play("PlayerDash", -1);

            // Desativa a gravidade temporariamente
            rb.gravityScale = 0;

            // Zera a velocidade para fazer a animação de maneira mais limpa, a mesma coisa ocorre no pulo.
            // Além disso evita problemas ao trocar de direção, exemplo ir para a direita e dar dash para a esquerda.
            rb.velocity = Vector2.zero;

            // Define uma força de impulso para o personagem em (X, Y)
            // Quando o personagem olha para a direita o local scale é positivo, fazendo com que o dash seja para a direita, e vice-versa.
            rb.AddForce(new Vector2(skin.localScale.x * 550, 0));

            // Restaura a gravidade após um curto intervalo
            Invoke("RestoreGravity", 0.5f);
        }



        comboTime = comboTime + Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && comboTime > 0.5f)
        {
            comboCount++;

            // Para impedir que receba valores de combo inexistentes como 3, 4, 5 e etc.
            if(comboCount > 2)
            {
                comboCount = 1;
            }

            comboTime = 0;
            // Vai concatenar o nome player attack com o contador, fazendo com que ele pegue o valor exato do combo
            skin.GetComponent<Animator>().Play("PlayerAttack" + comboCount, -1);

            if (comboCount == 1)
            {
                audioSource.PlayOneShot(attack1Sound, 0.75f);
            }

            else {
                audioSource.PlayOneShot(attack2Sound, 0.75f);
            }
        }

        if(comboTime >= 1f)
        {
            comboCount = 0;
        }

        if (Input.GetButtonDown("Jump") && floorCollider.GetComponent<FloorCollider>().canJump == true && rb.gravityScale != 0)
        {
            // Faz a animação acontecer na hora, cancelando outras animações. O -1 procura a animação entre todos os layers existentes
            skin.GetComponent<Animator>().Play("PlayerJump", -1);
            // É uma shorthand para Vector2(0, 0)
            rb.velocity = Vector2.zero;
            floorCollider.GetComponent<FloorCollider>().canJump = false;
            rb.AddForce(new Vector2(0, 925));
        }

        // Pega o eixo definido para o input (edit->project settings)
        // "Raw" pega o valor máximo instantaneamente, sem aumentar gadativamente até chegar ao máximo.
        // A multiplicação por 2 serve para aumentar a velocidade do personagem, mas pode ser qualquer número, inclusive tirar a multiplcação e deiar sem nada
        vel = new Vector2(Input.GetAxisRaw("Horizontal") * 6.5f, rb.velocity.y);

        // O personagem ativa a animação de corrida caso não esteja parado
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            // Vector3 é um vetor que guarda três posições (x, y, z)
            // Pega o próprio input do usuário para saber se x é 1 (direita) ou -1 (esquerda) e ajustar a escala de acordo
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            // Abre o animator e seta o booleano de corrida para true, ou seja, quando não estiver parado ele fará animação de corrida
            skin.GetComponent<Animator>().SetBool("PlayerRun", true);
        }

        else
        {
           skin.GetComponent<Animator>().SetBool("PlayerRun", false);
        }
    }

    // FixedUpdate deixa o a taxa de atualizaçao igual para todos, indenpendente do FPS do PC
    private void FixedUpdate()
    {
        if(dashTime > 0.5)
        {
            rb.velocity = vel;
        }
    }

    public void DestroyPlayer()
    {
        Destroy(transform.gameObject);
    }

    void RestoreGravity()
    {
        rb.gravityScale = 5.5f;
    }
}
