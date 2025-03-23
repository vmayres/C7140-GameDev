using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public static int score = 0; // Pontuação do jogador
    public static int life = 3; // Número de vidas do jogador
    public static bool win = true;

    private static BallControl ball;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball")?.GetComponent<BallControl>(); 

    }

    // Adiciona pontos ao score
    public static void AddScore(int points)
    {
        score += points;
    }

    // Decrementa a vida do jogador quando a bola cai
    public static void LoseLife()
    {
        life--;
        
        if (life <= 0)
        {
            win = false;
            SceneManager.LoadScene("GameOver");
        }
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Block");
        
        if(gos.Length == 0){
            if (scene.name == "Fase1"){
                SceneManager.LoadScene("Fase2");
            } else if(scene.name == "Fase2"){
                SceneManager.LoadScene("GameOver");
            }
        }

        scoreText.text = "Score: \n" + score;
        livesText.text = "Lives: \n" + life;

    }
}
