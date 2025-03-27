using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    public float minY = -3.5f;
    public float maxY = 3.5f;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 2.5f;
    public float minScale = 1.0f;
    public float maxScale = 1.3f;
    public int minAsteroids = 1;
    public int maxAsteroids = 3;

    public GameManager gm; // Referência ao GameManager

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            int asteroidCount = Random.Range(minAsteroids, maxAsteroids + 1);

            for (int i = 0; i < asteroidCount; i++)
            {
                SpawnSingleAsteroid();
            }

            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SpawnSingleAsteroid()
    {
        float spawnY = Random.Range(minY, maxY);
        int randomIndex = Random.Range(0, asteroidPrefabs.Length);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, transform.position.z);

        GameObject asteroid = Instantiate(asteroidPrefabs[randomIndex], spawnPosition, Quaternion.identity);

        float randomScale = Random.Range(minScale, maxScale);
        asteroid.transform.localScale *= randomScale;

        // Passa o GameManager para o asteroide instanciado
        AsteroidMovement script = asteroid.GetComponent<AsteroidMovement>();
        if (script != null && gm != null)
        {
            script.gm = gm;
        }
    }
}
