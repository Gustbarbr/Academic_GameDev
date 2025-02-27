using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0;
    public static int PlayerLife = 3;
    public GUISkin layout;
    bool blueFlag;

    public void Fase2()
    {
        // Pega o nome da cena atual
        Scene cenaAtual = SceneManager.GetActiveScene();
        string nomeCena = cenaAtual.name;

        // Se está na última fase e todos os blocos foram destruídos, então a tela de vitória é mostrada
        if (nomeCena == "Cena1" && GreyBlocksDestroyed() == true && BlueBlocksDestroyed() == true)
        {
            SceneManager.LoadScene("Cena2");
        }
    }

    public void Vitoria()
    {
        // Pega o nome da cena atual
        Scene cenaAtual = SceneManager.GetActiveScene();
        string nomeCena = cenaAtual.name;

        // Se está na última fase e todos os blocos foram destruídos, então a tela de vitória é mostrada
        if (nomeCena == "Cena2" && GreyBlocksDestroyed() == true && BlueBlocksDestroyed() == true && GreyBlocksDestroyed() == true && GreenBlocksDestroyed() == true && YellowBlocksDestroyed() == true && RedBlocksDestroyed() == true && PurpleBlocksDestroyed() == true)
        {
            SceneManager.LoadScene("CenaGanhar");
        }
    }

    public bool GreyBlocksDestroyed()
    {
        // Basicamente pega uma lista com todos objetos que possuam o script BlueBlock
        GreyBlock[] greyBlocks = Object.FindObjectsByType<GreyBlock>(FindObjectsSortMode.None);

        // Se a quantidade de blocos azuis for igual a zero, então todos foram destruidos
        return greyBlocks.Length == 0;
    }

    public bool BlueBlocksDestroyed()
    {
        // Basicamente pega uma lista com todos objetos que possuam o script BlueBlock
        BlueBlock[] blueBlocks = Object.FindObjectsByType<BlueBlock>(FindObjectsSortMode.None);

        // Se a quantidade de blocos azuis for igual a zero, então todos foram destruidos
        return blueBlocks.Length == 0;
    }

    // São iguais ao blue
    public bool GreenBlocksDestroyed()
    {
        GreenBlock[] greenBlocks = Object.FindObjectsByType<GreenBlock>(FindObjectsSortMode.None);

        return greenBlocks.Length == 0;
    }

    public bool YellowBlocksDestroyed()
    {
        YellowBlock[] yellowBlocks = Object.FindObjectsByType<YellowBlock>(FindObjectsSortMode.None);

        return yellowBlocks.Length == 0;
    }

    public bool RedBlocksDestroyed()
    {
        RedBlock[] redBlocks = Object.FindObjectsByType<RedBlock>(FindObjectsSortMode.None);

        return redBlocks.Length == 0;
    }

    public bool PurpleBlocksDestroyed()
    {
        PurpleBlock[] purpleBlocks = Object.FindObjectsByType<PurpleBlock>(FindObjectsSortMode.None);

        return purpleBlocks.Length == 0;
    }
}
