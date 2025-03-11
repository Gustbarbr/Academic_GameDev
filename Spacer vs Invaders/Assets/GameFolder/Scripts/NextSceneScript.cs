using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        var enemies = GameObject.FindWithTag("Enemy");
        if(enemies == null && scene.name == "Cena1"){ 
            SceneManager.LoadScene("CenaGanhar");
        }
    }
}
