using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float projectileSpeed = 15f;
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocityY = -projectileSpeed; // Alterado para mover para baixo
        if (rb2d.transform.position.y < -14f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ScoreManager.LostLife();

        }
    }

}
