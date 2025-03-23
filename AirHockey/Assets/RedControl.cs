using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedControl : MonoBehaviour
{
    public float boundY = 7.9f;            // Define os limites em Y
    public float boundX = 4.9f;            // Define os limites em X
    private Rigidbody2D mallet;            // Corpo rígido 2D do mallet
    public float moveSpeed = 5f;           // Velocidade inicial
    public float acceleration = 2f;        // Aceleração do movimento
    public float maxSpeed = 8f;            // Velocidade máxima
    public float idleZoneY = 4.0f;         // Zona de idle definida acima de Y = 4

    // Start é chamado antes do primeiro frame
    void Start()
    {
        mallet = GetComponent<Rigidbody2D>();  // Inicializa o mallet
    }

    // Update é chamado uma vez por frame
    void FixedUpdate()
    {
        GameObject puck = GameObject.FindGameObjectWithTag("Puck"); // Encontra o puck

        if (puck != null && puck.transform.position.y > 0)
        {
            Vector2 puckPos = puck.transform.position;  // Posição do puck

            // Calcula a direção para o puck
            Vector2 direction = (puckPos - mallet.position).normalized;

            // Aplica aceleração até o limite de velocidade máxima
            moveSpeed = Mathf.Min(moveSpeed + acceleration * Time.fixedDeltaTime, maxSpeed);

            // Define a nova velocidade do mallet (movendo suavemente)
            mallet.linearVelocity = direction * moveSpeed;
        }
        else
        {
            // Se o mallet estiver abaixo da zona de idle, ele retorna para idleZoneY
            if (mallet.position.y < idleZoneY)
            {
                Vector2 idlePosition = new Vector2(mallet.position.x, idleZoneY);
                Vector2 direction = (idlePosition - mallet.position).normalized;

                mallet.linearVelocity = direction * moveSpeed;
            }
            else
            {
                // Para o movimento caso já esteja na idle zone
                mallet.linearVelocity = Vector2.zero;
            }
        }
    }
}

