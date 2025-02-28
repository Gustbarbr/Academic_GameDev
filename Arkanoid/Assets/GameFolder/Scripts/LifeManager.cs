using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeManager : MonoBehaviour
{

    public TextMeshProUGUI lifeText;

    int life = 3;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        lifeText.text = "LIFE: " + life.ToString();
    }

    public void LoseLife(){
        life-=1;
        lifeText.text = "LIFE: " + life.ToString();
    }

}
