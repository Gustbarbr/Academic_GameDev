using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    void OnEnable()
    {
        // Enquanto blockRaycasts estiver desabilitado, os botões não poderão ser clicados
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void Update()
    {
        GetComponent<CanvasGroup>().alpha += Time.deltaTime * 0.5f;
    }
}
