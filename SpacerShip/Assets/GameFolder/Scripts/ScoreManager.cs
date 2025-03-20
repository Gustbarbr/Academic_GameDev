using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public List<ParallaxScript> parallaxObjects = new List<ParallaxScript>();  // Lista dos 4 objetos de parallax
    public List<ParticleCollision> particleCollision = new List<ParticleCollision>();  // Referência ao script ParticleCollision

    public int score = 0;

    void Start(){
        score = 0;
        scoreText.text = "SPACERSON POINTS: " + score.ToString();
    }

    public void GettingPoints(){
        score += 50;
        scoreText.text = "SPACERSON POINTS: " + score.ToString();

        if(score >= 2500){
            SceneManager.LoadScene("Victory");
        }
        
        // Quando a pontuação atingir 500, 1250 e 2000 a velocidade do parallax é reduzida por 5 segundos
        if(score == 500 || score == 1250 || score == 2000){
            foreach (var parallax in parallaxObjects)
            {
                parallax.SlowDownParallax();  // Aplica o slow down para todos os objetos na lista
            }
            foreach (var particle in particleCollision)
            {
                particle.SlowDownParticles();  // Chama a função para diminuir a velocidade das partículas
            }
        }
    }
}
