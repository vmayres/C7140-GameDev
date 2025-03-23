using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int health; // Quantidade de vezes que precisa ser atingido
    public int scoreValue; // Pontos ao quebrar o bloco

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        string spriteName = spriteRenderer.sprite.name; // Obtém o nome do sprite

        // Define a vida do bloco com base na cor
        if (spriteName == "element_grey_rectangle"){
            health = 2;
        } 
        else if (spriteName == "element_yellow_rectangle"){
            health = 3;
        } 
        else health = 1;

        scoreValue = health*100;
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            GameManager.AddScore(scoreValue); // Adiciona pontos ao score
            Destroy(gameObject);
        }
    }
}
