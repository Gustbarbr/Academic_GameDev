using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        var enemies = GameObject.FindWithTag("Enemy");
        if(enemies == null && scene.name == "Cena1"){ 
            SceneManager.LoadScene("Cena2");
        }
        else if(enemies == null && scene.name == "Cena2"){
            SceneManager.LoadScene("CenaGanhar");
        }
    }
}
