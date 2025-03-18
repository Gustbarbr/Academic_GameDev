using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLaser : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){

        if (collider.gameObject.CompareTag("Laser"))
        {
            Destroy(collider.gameObject);  // Destroi o laser
        }
    }
}
