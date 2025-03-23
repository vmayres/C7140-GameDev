using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; // Pontuação do player 1
    public static int PlayerScore2 = 0; // Pontuação do player 2

    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Referência ao objeto bola

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Puck"); // Busca a referência da bola
    }

    // incrementa a potuação
    public static void Score (string goalsID) {
        if (goalsID == "RedGoal")
        {
            PlayerScore1++;
        } else
        {
            PlayerScore2++;
        }
    }

    // Gerência da pontuação e fluxo do jogo
    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 200 - 12, 20, 200, 200), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 - 200 - 12, 320, 200, 200), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width - 200, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore1 == 10)
        {
            GUI.color = Color.black; // Define a cor preta para o fundo
            GUI.Box(new Rect(Screen.width / 2 - 100, 200, 200, 100), ""); // Retângulo de fundo

            GUI.color = Color.white; // Resetar cor para que o texto fique branco
            GUI.Label(new Rect(Screen.width / 2 - 80, 225, 2000, 1000), "PLAYER RED WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } else if (PlayerScore2 == 10)
        {
            GUI.color = Color.black; // Define a cor preta para o fundo
            GUI.Box(new Rect(Screen.width / 2 - 100, 200, 200, 100), ""); // Retângulo de fundo
            GUI.color = Color.white; // Resetar cor para que o texto fique branco

            GUI.Label(new Rect(Screen.width / 2 - 80, 225, 2000, 1000), "PLAYER BLUE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }

}
