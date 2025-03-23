using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour {

    // Verifica colisões da bola nas paredes
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.tag == "Puck")
        {
            string goalName = transform.name;
            GameManager.Score(goalName);
            hitInfo.gameObject.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }
}

