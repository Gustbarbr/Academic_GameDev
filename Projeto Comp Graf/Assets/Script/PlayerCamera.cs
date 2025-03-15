using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Variaveis de sensibilidade da camera
    public float senseX;
    public float senseY;

    // Variavel para orientacao do player
    public Transform orientation;

    // Variaveis de rotacionamento da camera
    float xRotation;
    float yRotation;


    void Start()
    {
        // Trava o cursor no meio da tela
        Cursor.lockState = CursorLockMode.Locked;
        // Deixa o cursor invisivel
        Cursor.visible = false;
    }


    void Update()
    {
        // Captura o movimento do mouse, fazendo com que ele atinja o valor maximo instantaneamente, ao inves de gradualmente
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senseX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senseY;

        yRotation += mouseX;
        xRotation -= mouseY;

        // Faz com que o player não possa olhar mais que 90º para direita ou esquerda
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotaciona camera e orientacao
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
