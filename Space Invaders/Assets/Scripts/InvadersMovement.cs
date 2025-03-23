using UnityEngine;

public class InsvaderMovement : MonoBehaviour
{
    [Header("Insvaders")]
    public GameObject squidPrefab;
    public GameObject crabPrefab;
    public GameObject octopusPrefab;
    public AnimationCurve speedCurve;
    private Vector3 direction = Vector3.right;
    private Vector3 initialPosition;

    [Header("Grid Configurations")]
    public int columns = 7;
    public float spacing = 2f;

    [Header("Missiles")]
    public GameObject projectilePrefab;
    public float missileSpawnRate = 1f;

    [Header("Invaders")]
    public float baseSpeed = 4f; // Aumentando a velocidade inicial em 4 vezes

    private void Awake()
    {
        initialPosition = transform.position;
        CreateInvaderGrid();
    }

    private void Start()
    {
        InvokeRepeating(nameof(TryToShoot), missileSpawnRate, missileSpawnRate);
    }

    private void CreateInvaderGrid()
    {
        GameObject[] prefabs = { squidPrefab, crabPrefab, octopusPrefab};
        int[] rowCounts = { 1, 2, 2 }; // Quantidade de linhas para cada tipo

        int rowIndex = 0;
        for (int i = 0; i < rowCounts.Length; i++)
        {
            for (int j = 0; j < rowCounts[i]; j++)
            {
                Vector3 rowPosition = new Vector3(-spacing * (columns - 1) * 0.5f, 7f - (spacing * rowIndex), 0f);
                for (int k = 0; k < columns; k++)
                {
                    GameObject invader = Instantiate(prefabs[i], transform);
                    invader.transform.localPosition = rowPosition + new Vector3(spacing * k, 0f, 0f);
                }
                rowIndex++;
            }
        }
    }

    private void Update()
    {
        int aliveCount = GetAliveCount();
        float speedMultiplier = 1f + ((columns * 3 - aliveCount) * 0.05f); // Aumenta a velocidade conforme os invasores são eliminados
        float speed = baseSpeed * speedMultiplier * Time.deltaTime;
        transform.position += speed * direction;

        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy) continue;

            if (invader.position.y <= -13f)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            }

            if ((direction == Vector3.right && invader.position.x >= 13f) ||
                (direction == Vector3.left && invader.position.x <= -14f))
            {
                AdvanceRow();
                break;
            }
        }
    }

    private void AdvanceRow()
    {
        direction = new Vector3(-direction.x, 0f, 0f);
        transform.position += Vector3.down * spacing;
    }

    public void TryToShoot()
    {
        Transform[] aliveInvaders = GetAliveInvaders();
        if (aliveInvaders.Length > 0)
        {
            int randomIndex = Random.Range(0, aliveInvaders.Length);
            Transform shooter = aliveInvaders[randomIndex];

            if (shooter != null && projectilePrefab != null)
            {
                GameObject projectile = Instantiate(projectilePrefab, shooter.position, Quaternion.identity);
                projectile.transform.position = new Vector3(projectile.transform.position.x, projectile.transform.position.y, 1f);
                projectile.tag = "Enemy Projectile";
            }
        }
    }

    private Transform[] GetAliveInvaders()
    {
        Transform[] invaders = new Transform[transform.childCount];
        int index = 0;
        foreach (Transform invader in transform)
        {
            if (invader.gameObject.activeInHierarchy)
            {
                invaders[index] = invader;
                index++;
            }
        }
        System.Array.Resize(ref invaders, index);
        return invaders;
    }

    public int GetAliveCount()
    {
        int count = 0;
        foreach (Transform invader in transform)
        {
            if (invader.gameObject.activeSelf)
            {
                count++;
            }
        }
        return count;
    }
}
