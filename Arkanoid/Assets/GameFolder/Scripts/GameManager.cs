using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0;
    public static int PlayerLife = 3;
    public GUISkin layout;
    GameObject theBall;
    GameObject player;

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ResetGreyBlock()
    {
        // Pega uma lista de objetos com o script "GreyBlock"
        GreyBlock[] greyBlocks = Object.FindObjectsByType<GreyBlock>(FindObjectsSortMode.None);

        // Para cada objeto que tenha o script, "revive" o bloco
        foreach (GreyBlock block in greyBlocks)
        {
            block.GetComponent<SpriteRenderer>().enabled = true;
            block.GetComponent<BoxCollider2D>().enabled = true;
            block.GetComponent<GreyBlock>().enabled = true;
        }
    }

    public bool GreysDestroyed()
    {
        // Verifica se há blocos cinzas restantes
        GreyBlock[] greyBlocks = Object.FindObjectsByType<GreyBlock>(FindObjectsSortMode.None);
        
        // Se houver blocos cinzas, retorna true, caso contrário, retorna false
        return greyBlocks.Length == 0;
    }
    
    public bool BlueDestroyed()
    {
        // Verifica se há blocos cinzas restantes
        BlueBlock[] blueBlocks = Object.FindObjectsByType<BlueBlock>(FindObjectsSortMode.None);
        
        // Se houver blocos blue, retorna true, caso contrário, retorna false
        return blueBlocks.Length == 0;
    }

    public bool GreenDestroyed()
    {
        // Verifica se há blocos cinzas restantes
        GreenBlock[] greenBlocks = Object.FindObjectsByType<GreenBlock>(FindObjectsSortMode.None);
        
        // Se houver blocos blue, retorna true, caso contrário, retorna false
        return greenBlocks.Length == 0;
    }

    public bool YellowDestroyed()
    {
        // Verifica se há blocos cinzas restantes
        YellowBlock[] yellowBlocks = Object.FindObjectsByType<YellowBlock>(FindObjectsSortMode.None);
        
        // Se houver blocos blue, retorna true, caso contrário, retorna false
        return yellowBlocks.Length == 0;
    }

    public bool RedDestroyed()
    {
        // Verifica se há blocos cinzas restantes
        RedBlock[] redBlocks = Object.FindObjectsByType<RedBlock>(FindObjectsSortMode.None);
        
        // Se houver blocos blue, retorna true, caso contrário, retorna false
        return redBlocks.Length == 0;
    }

    public bool PurpleDestroyed()
    {
        // Verifica se há blocos cinzas restantes
        PurpleBlock[] purpleBlocks = Object.FindObjectsByType<PurpleBlock>(FindObjectsSortMode.None);
        
        // Se houver blocos blue, retorna true, caso contrário, retorna false
        return purpleBlocks.Length == 0;
    }

    void Update()
    {
        // Verifica se o player morreu
        if (PlayerLife <= 0)
        {
            RestartScene(); // Se o player morreu, reinicia a cena
        }

        // Chama o método para verificar se todos os blocos cinzas foram destruídos e carrega a próxima cena
        if (GreysDestroyed() && BlueDestroyed() && GreenDestroyed() && YellowDestroyed() && RedDestroyed() && PurpleDestroyed())
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // Obtém a cena ativa
        Scene scene = SceneManager.GetActiveScene();

        // Se a cena atual for "Cena1", carrega "Cena2"
        if (scene.name == "Cena1")
        {
            SceneManager.LoadScene("Cena2");
        }
    }

    void RestartScene()
    {
        // Reinicia a cena atual (resetando tudo)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetBlueBlock()
    {
        // Pega uma lista de objetos com o script "BlueBlock"
        BlueBlock[] blueBlocks = Object.FindObjectsByType<BlueBlock>(FindObjectsSortMode.None);

        // Para cada objeto que tenha o script, "revive" o bloco
        foreach (BlueBlock block in blueBlocks)
        {
            block.GetComponent<SpriteRenderer>().enabled = true;
            block.GetComponent<BoxCollider2D>().enabled = true;
            block.GetComponent<BlueBlock>().enabled = true;
            block.hp = 2;
        }
    }
}
