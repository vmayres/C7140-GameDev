using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float projectileSpeed = 25f;
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocityY = projectileSpeed;
        if (rb2d.transform.position.y > 11f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        // Marca a pontuação conforme a tag do invader
        if (other.gameObject.CompareTag("Octopus"))
        {
            ScoreManager.AddScore(10);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Crab"))
        {
            ScoreManager.AddScore(20);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Squid"))
        {
            ScoreManager.AddScore(40);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Mothership"))
        {
            ScoreManager.AddScore(200);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            // Nao faz nada
        }

    }
}
