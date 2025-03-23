using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public Sprite[] blockSprites;
    public int rows = 5; // Número de linhas de blocos
    public int columns = 12; // Número de colunas de blocos
    public float blockWidth = 0.64f;
    public float blockHeight = 0.32f;

    void Start()
    {
        GenerateBlocks();
    }

    void GenerateBlocks()
    {
        // Calcula a largura total dos blocos na tela
        float totalWidth = columns * blockWidth;
        float totalHeight = rows * blockHeight;

        // Define a posição inicial para centralizar os blocos
        Vector2 startPosition = new Vector2(-totalWidth / 2f + blockWidth / 2f, 4f); 

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 position = startPosition + new Vector2(col * blockWidth, -row * blockHeight);

                GameObject newBlock = Instantiate(blockPrefab, position, Quaternion.identity);

                SpriteRenderer sr = newBlock.GetComponent<SpriteRenderer>();
                Block blockScript = newBlock.GetComponent<Block>();

                if (sr != null && blockSprites.Length > 0)
                {
                    // Define a cor com base na linha
                    int spriteIndex = row % blockSprites.Length; // Evita erro se houver mais linhas que sprites
                    sr.sprite = blockSprites[spriteIndex];
                }
            }
        }
    }
}
