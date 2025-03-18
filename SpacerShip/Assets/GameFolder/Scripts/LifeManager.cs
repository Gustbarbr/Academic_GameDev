using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public TextMeshProUGUI lifeText;

    public int life = 3;

    void Start(){
        life = 3;
        lifeText.text = "LIFE: " + life.ToString();
    }

    public void LosingHealth(){
        life -= 1;
        lifeText.text = "LIFE: " + life.ToString();
    }
}
