using UnityEngine;

public class ExitGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                // Se estiver no Editor, parar a execução do jogo
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                // Se estiver em um build, fechar o aplicativo
                Application.Quit();
            #endif
        }
    }
}
