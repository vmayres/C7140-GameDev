using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] public float baseSpeed = 1f; // Velocidade base do asteroide
    private float speed; // Velocidade final do asteroide
    private float destroyX = -6f; // Posi��o X onde o asteroide ser� destru�do

    public GameManager gm; // Refer�ncia ao GameManager

    void Update()
    {
        if (gm != null)
        {
            baseSpeed = gm.speedMultiplier;
        }

        // Move o asteroide para a esquerda
        speed = baseSpeed * Random.Range(3.0f, 4.5f);
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Verifica se o asteroide atingiu a posi��o de destrui��o
        if (transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
    }
}
