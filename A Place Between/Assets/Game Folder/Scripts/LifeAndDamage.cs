using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAndDamage : MonoBehaviour
{
    PlayerControl player;
    EnemyControl enemy;
    void Start()

    {
        if(this.tag == "Player"){
            player = GetComponent<PlayerControl>();
        }

        else if(this.tag == "Enemy"){
            enemy = GetComponent<EnemyControl>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Bullet" && this.tag == "Enemy"){
            if(enemy.hp > 1){
                enemy.hp -= 1;
            }
            else if(enemy.hp <= 1){
                Destroy(this.gameObject);
            }
        }
    }
}
