using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public GameManager gm;   // Referencia ao Script Gamemanager

    void Start()
    {
        float distancia = GameManager.distanciaFinal;
        string texto = distancia.ToString("0.#####E+0");
        finalScoreText.text = $"FINAL DISTANCE: {texto} km";
    }
}
