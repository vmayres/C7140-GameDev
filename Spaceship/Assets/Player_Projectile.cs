using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 15f;
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocityX = projectileSpeed;
        if (rb2d.transform.position.x > 6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Asteroid")){
            Destroy(other.gameObject);
            Destroy(gameObject);
            //ScoreManager.AddScore(10);
        }
        else{
            // Nao faz nada
        }

    }

}
