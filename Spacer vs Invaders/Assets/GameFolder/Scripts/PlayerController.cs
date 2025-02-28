using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    private float boundX = 10.5f;
    private Rigidbody2D rigidbody;
    //parte de tiro que vi num tutorial:
    public GameObject ProjectilePrefab;
    public Transform LaunchOffset;
    public float fireRate = 0.5f; // Taxa de tiro (em segundos)
    private float nextFireTime = 0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rigidbody.velocity;
        if(Input.GetKey(KeyCode.LeftArrow)){
            vel.x = -speed;
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            vel.x = speed;
        }
        else{
            vel.x = 0;
        }
        rigidbody.velocity = vel;

        var pos = transform.position;
        if(pos.x > boundX){
            pos.x = boundX;
        }
        else if(pos.x<-boundX){
            pos.x = -boundX;
        }
        transform.position = pos;

        //PARTE DE TIROOOOO:
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireTime)
        {
            // Instancia o projétil na posição do LaunchOffset com a rotação do player
            Instantiate(ProjectilePrefab, LaunchOffset.position, LaunchOffset.rotation);

            // Atualiza o tempo do próximo disparo
            nextFireTime = Time.time + fireRate;
        }

    }
}
