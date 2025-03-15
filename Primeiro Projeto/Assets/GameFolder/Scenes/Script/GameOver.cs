using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    void OnEnable()
    {
        // Enquanto blockRaycasts estiver desabilitado, os bot�es n�o poder�o ser clicados
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void Update()
    {
        GetComponent<CanvasGroup>().alpha += Time.deltaTime * 0.5f;
    }
}
