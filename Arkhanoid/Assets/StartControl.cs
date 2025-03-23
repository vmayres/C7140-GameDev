using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartControl : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(startGame);
    }

    public void startGame()
    {
        SceneManager.LoadScene("Fase1");
    }
}
