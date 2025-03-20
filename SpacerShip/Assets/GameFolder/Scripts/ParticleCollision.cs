using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ParticleCollision : MonoBehaviour
{
    public PlayerController player;
    public ScoreManager scoreManager;
    public LifeManager lifeManager;
    public ParticleSystem particleSystem;  // Referência ao sistema de partículas

    void Start(){
         player = FindObjectOfType<PlayerController>();
         scoreManager = FindObjectOfType<ScoreManager>();
         lifeManager = FindObjectOfType<LifeManager>();
         particleSystem = GetComponent<ParticleSystem>();  // Obtém o sistema de partículas
    }

    void Update(){
        if (player.hp <= 0){
            SceneManager.LoadScene("Morte");
        }
    }

    // Este método é chamado quando uma partícula colide com outro objeto
    void OnParticleCollision(GameObject other)
    {
        // Verifica se o objeto colidido é a bala
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            scoreManager.GettingPoints();
        }
        if (other.CompareTag("Player"))
        {
            player.hp -= 1;
            lifeManager.LosingHealth();
        }
    }

    // Função para reduzir a velocidade das partículas
    public void SlowDownParticles(){
        var main = particleSystem.main;  // Obtém a configuração principal do sistema de partículas
        main.startSpeed = main.startSpeed.constant * 0.5f;  // Diminui a velocidade das partículas pela metade
        StartCoroutine(ResetSpeedAfterTime(main, 5f));
    }

    private IEnumerator ResetSpeedAfterTime(ParticleSystem.MainModule main, float time)
    {
        yield return new WaitForSeconds(time);  // Espera pelo tempo especificado (5 segundos)
        main.startSpeed = main.startSpeed.constant * 2f;  // Restaura a velocidade original
    }
}
