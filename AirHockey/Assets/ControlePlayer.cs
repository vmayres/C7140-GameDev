using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer : MonoBehaviour
{
    public float boundY = 7.9f;            // Define os limites em Y
    public float boundX = 4.9f;            // Define os limites em Y
    private Rigidbody2D mallet;               // Define o corpo rigido 2D que representa o mallet

    // Start is called before the first frame update
    void Start()
    {
        mallet = GetComponent<Rigidbody2D>();     // Inicializa o mallet
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPos = new Vector2(
            Mathf.Clamp(mousePos.x, -boundX + 0.5f, boundX - 0.5f),
            Mathf.Clamp(mousePos.y, -boundY + 0.5f, -0.5f)
        );

        mallet.MovePosition(targetPos);  // Movimenta o jogador usando física
    }
}
