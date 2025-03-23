using TMPro.Examples;
using UnityEngine;

public class MotheshipController : MonoBehaviour
{
    public float mothershipSpeed = 15f;
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocityX = mothershipSpeed;
        if (rb2d.transform.position.x > 19f)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Debug.Log("Mothership destruido");
    }
}
