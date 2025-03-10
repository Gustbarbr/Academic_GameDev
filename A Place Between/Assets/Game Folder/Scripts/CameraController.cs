using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform followPlayer; // Guarda o objeto do player
    private void FixedUpdate()
    {
        // A posicao da camera eh igual a do player
        transform.position = new Vector3(followPlayer.position.x, followPlayer.position.y, transform.position.z);
    }
}
