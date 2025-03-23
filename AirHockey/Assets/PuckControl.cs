using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckControl : MonoBehaviour
{
    private Rigidbody2D puck;               // Define o corpo rigido 2D que representa a bola
    public AudioSource source;
    public float maxSpeed = 15f;   // Velocidade máxima do mallet
    
    // Start is called before the first frame update
    void Start()
    {
        puck = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = puck.linearVelocity.x;
            vel.y = (puck.linearVelocity.y / 2) + (coll.collider.attachedRigidbody.linearVelocity.y / 3);

            // Limita a velocidade máxima
            puck.linearVelocity = Vector2.ClampMagnitude(vel, maxSpeed);
        }
        source.Play();
    }

    // Reinicializa a posição e velocidade da bola
    void ResetBall(){
        puck.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    public void RestartGame(){
        ResetBall();
    }
}
