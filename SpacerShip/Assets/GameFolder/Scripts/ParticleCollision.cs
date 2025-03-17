using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleCollision : MonoBehaviour
{
    public PlayerController player;

    void Start(){
         player = FindObjectOfType<PlayerController>();
    }

    void Update(){
        if (player.hp<=0){
            SceneManager.LoadScene("Morte");
        }
    }
    // Este método é chamado quando uma partícula colide com outro objeto
    void OnParticleCollision(GameObject other)
    {
        // Verifica se o objeto colidido é a bala
        if (other.CompareTag("Laser"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player")){
            player.hp -=1;
        }
    }
}
