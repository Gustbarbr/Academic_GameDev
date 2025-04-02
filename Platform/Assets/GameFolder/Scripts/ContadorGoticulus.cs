using UnityEngine;
using UnityEngine.SceneManagement; 

public class ContadorGoticulus : MonoBehaviour
{
    Scene scene;
    string cenaAtual;

    private void Start(){
        scene =  SceneManager.GetActiveScene();
        cenaAtual = scene.name;
    }

    void Update()
    {
        if (transform.childCount == 0 && cenaAtual == "CenaInicial")
        {
            SceneManager.LoadScene("CenaProximaFase");
        }
        else if (transform.childCount == 0 && cenaAtual == "CenaFinal")
        {
            SceneManager.LoadScene("CenaGanhar");
        }
    }

}
