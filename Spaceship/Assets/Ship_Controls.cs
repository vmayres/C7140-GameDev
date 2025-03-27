using UnityEngine;

public class Ship_Controls : MonoBehaviour
{
    public static Ship_Controls instance;

    [SerializeField] float playerMoveSpeed = 10f;

    public Transform projectileTransform;
    public GameObject prefab;

    public GameManager gm;   // Referencia ao Script Gamemanager
    public FuelBar fuelBar;  // Referência ao script FuelBar

    private void Update()
    {
        // Movimento
        float translationX = Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;
        float translationY = Input.GetAxis("Vertical") * playerMoveSpeed * Time.deltaTime;

        transform.Translate(translationX, translationY, 0);

        // Limites de tela
        if (transform.position.x < -4.4f)
        {
            transform.position = new Vector3(-4.4f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 4.4f)
        {
            transform.position = new Vector3(4.4f, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -3.3f)
        {
            transform.position = new Vector3(transform.position.x, -3.3f, transform.position.z);
        }
        if (transform.position.y > 3.3f)
        {
            transform.position = new Vector3(transform.position.x, 3.3f, transform.position.z);
        }

        // Disparo
        if (Input.GetKeyDown(KeyCode.Space) && GameObject.FindWithTag("Player Projectile") == null)
        {
            if (gm != null && gm.UseAmmo())
            {
                Instantiate(prefab, projectileTransform.position, transform.rotation);
            }
            else
            {
                Debug.Log("Sem munição!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid"))
        {
            if (gm != null)
            {
                gm.TakeDamage(1);
            }

            Destroy(other.gameObject);
        }

        if (other.CompareTag("MoreAmmo"))
        {
            if (gm != null)
            {
                gm.AddAmmo(10);
            }

            Destroy(other.gameObject);
        }

        if (other.CompareTag("MoreFuel"))
        {
            if (gm != null)
            {
                fuelBar.RefillFuel(15f);
            }

            Destroy(other.gameObject);
        }
    }

}
