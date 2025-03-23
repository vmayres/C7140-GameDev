using UnityEngine;
using UnityEngine.SceneManagement; // Importa SceneManager para mudar de cena
using System.Collections;


public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;

    [SerializeField] float playerMoveSpeed = 10f;

    public Transform projectileTransform;
    public GameObject prefab;

    public Sprite damagedSprite;
    private Sprite originalSprite;
    private SpriteRenderer spriteRenderer;

    private void Update()
    {

        float translation = Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;

        transform.Translate(translation, 0, 0);

        if (transform.position.x < -15f)
        {
            transform.position = new Vector3(-15f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 15f)
        {
            transform.position = new Vector3(15f, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && GameObject.FindWithTag("Player Projectile") == null)
        {
            Instantiate(prefab, projectileTransform.position, transform.rotation);
        }
    }

    void OnDestroy()
    {
        Debug.Log("Player destruido");
        ScoreManager.LostLife();
    }

}
