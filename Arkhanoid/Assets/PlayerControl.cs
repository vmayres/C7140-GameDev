using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public KeyCode moveLeft = KeyCode.A;      // Move a plataforma para esquerda
    public KeyCode moveRight = KeyCode.D;    // Move a plataforma para direita
    public float speed = 10.0f;             // Define a velocidade da raquete
    public float boundX = 3.8f;            // Define os limites em X
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete

    }

    // Update is called once per frame
    void Update () {

        var vel = rb2d.velocity;                // Acessa a velocidade da raquete
        if (Input.GetKey(moveLeft)) {             // Velocidade da Raquete para ir para esquerda
            vel.x = -speed;
        }
        else if (Input.GetKey(moveRight)) {      // Velocidade da Raquete para ir para direita
            vel.x = speed;                    
        }
        else {
            vel.x = 0;                          // Velociade para manter a raquete parada
        }
        rb2d.velocity = vel;                    // Atualizada a velocidade da raquete

        var pos = transform.position;           // Acessa a Posição da raquete
        if (pos.x > boundX) {                  
            pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite esuqerdo
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite direito
        }
        transform.position = pos;               // Atualiza a posição da raquete
    }
}
