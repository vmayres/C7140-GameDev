using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float lenght;
    public float parallaxEffect;
    [SerializeField] public float baseSpeed = 1f;

    public GameManager gm; // Referência ao GameManager

    void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        if (gm != null)
        {
            baseSpeed = gm.speedMultiplier;
        }

        transform.position += Vector3.left * Time.deltaTime * parallaxEffect * baseSpeed;
        if (transform.position.x < -lenght)
        {
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
        }
    }

}