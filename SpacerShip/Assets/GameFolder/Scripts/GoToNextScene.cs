using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    void Update(){
        if(Input.GetKey(KeyCode.Space)){
            SceneManager.LoadScene("CenaInicial");
        }
    }
}
