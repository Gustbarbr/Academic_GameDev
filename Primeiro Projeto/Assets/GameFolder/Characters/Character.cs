using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{

    public int life;
    public Transform skin;
    public Transform cam;

    // Guarda o componente de texto do objeto HearthCountText
    public Text HeartCountText;

    public AudioClip bossBattleMusic;
    public AudioClip youWin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0 && !transform.name.Equals("BossBrain"))
        {
            // O -1 faz encontrar a animação em qualquer layer
            skin.GetComponent<Animator>().Play("Die", -1);
        }


        if (transform.CompareTag("Player"))
        {
            HeartCountText.text = "x" + life.ToString();

            if (SceneManager.GetActiveScene().name.Equals("Level5"))
            {
                cam.GetComponent<Animator>().enabled = false;
                cam.GetComponent<Camera>().orthographicSize = 10f;
                cam.position = new Vector3(14.5f, 5, -1);

                // Para o player não mover a câmera, deixando ela estática
                cam.parent = null;

                // Tem dois "MoveGameObjectToScene", use o que diz "(GameObject go, ...)"
                SceneManager.MoveGameObjectToScene(cam.gameObject, SceneManager.GetActiveScene());

                if (GameObject.Find("BossBrain").GetComponent<Character>().life > 0)
                {
                    if(cam.GetComponent<AudioSource>().clip != bossBattleMusic)
                    {
                        cam.GetComponent<AudioSource>().clip = bossBattleMusic;
                        cam.GetComponent<AudioSource>().Play();
                    }
                    
                }
                else
                {
                    GameObject.Find("YouWin").GetComponent<GameOver>().enabled = true;
                    GetComponent<PlayerController>().enabled = false;
                    GetComponent<CapsuleCollider2D>().enabled = false;
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

                    if (cam.GetComponent<AudioSource>().clip != null)
                    {
                        cam.GetComponent<AudioSource>().Stop();
                        cam.GetComponent<AudioSource>().clip = null;
                        cam.GetComponent<AudioSource>().PlayOneShot(youWin);
                    }
                }
                
            }
        }


        if (transform.name.Equals("BossBrain"))
        {

            // 30 = 1.09
            // X = ?
            transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(1.78f, life * 1.09f/30);

            if(life <= 0)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            }
        }
        
    }

    // Vai chamar a função e passar o valor a ser descontado como parâmetro e coloca a animação de dano no player
    public void PlayerDamage(int value)
    {
        life = life - value;
        skin.GetComponent<Animator>().Play("PlayerDamage", 1);
        cam.GetComponent<Animator>().Play("CameraPlayerDamage", -1);
        GetComponent<PlayerController>().audioSource.PlayOneShot(GetComponent<PlayerController>().damageSound);
    }
}
