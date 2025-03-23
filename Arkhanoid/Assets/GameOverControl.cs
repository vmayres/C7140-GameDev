using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverControl : MonoBehaviour{

    public TMP_Text gameOverText;
    public TMP_Text scoreText;

    public Button RestartButton;
    public Button MenuButton; 
    public SpriteRenderer backgroundRenderer; // Arraste o GameObject do fundo aqui
    public Sprite victoryBackground; // Fundo de vitória
    public Sprite defeatBackground; // Fundo de derrota
    void Start()
    {
        scoreText.text = "Final Score: " + GameManager.score;

        if (GameManager.win)
        {
            gameOverText.text = "Vitória! :) ";
            backgroundRenderer.sprite = victoryBackground; // Muda o fundo para vitória
        }
        else
        {
            gameOverText.text = "Derrota! :( ";
            backgroundRenderer.sprite = defeatBackground; // Muda o fundo para derrota
        }

        RestartButton.onClick.AddListener(RestartGame);
        MenuButton.onClick.AddListener(GoToMenu);
    }

    // Reinicia a cena atual
    public void RestartGame()
    {
        GameManager.score = 0;
        GameManager.life = 3;
        SceneManager.LoadScene("Fase1");
    }

    // Volta para a tela do Menu
    public void GoToMenu()
    {
        SceneManager.LoadScene("Start");  // Certifique-se que a cena do menu se chama "Start"
    }
}
