using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneScript : MonoBehaviour
{

    PlayerController player;
    void Start(){
        player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        var enemies = GameObject.FindWithTag("Enemy");
        if(enemies == null && scene.name == "Cena1"){ 
            Destroy(player.gameObject);
            SceneManager.LoadScene("CenaGanhar");
        }
    }
}
