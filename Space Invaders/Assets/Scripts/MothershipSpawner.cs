using UnityEngine;

public class MothershipSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mothershipPrefab;  // O prefab da Mothership a ser instanciado
    private float spawnMinTime = 20f;  // Tempo mínimo de espera para spawn (20 segundos)
    private float spawnMaxTime = 30f;  // Tempo máximo de espera para spawn (30 segundos)
    private float timeToNextSpawn;  // Variável que controla o tempo até o próximo spawn

    void Start()
    {
        // Inicializa o tempo até o próximo spawn com um valor aleatório
        timeToNextSpawn = Random.Range(spawnMinTime, spawnMaxTime);
    }

    void Update()
    {
        // Chama a função TrySpawn a cada frame
        TrySpawn();
    }

    void TrySpawn()
    {
        // Diminui o tempo até o próximo spawn
        timeToNextSpawn -= Time.deltaTime;

        // Se o tempo chegou a zero ou abaixo, realiza o spawn
        if (timeToNextSpawn <= 0f)
        {
            // Instancia a Mothership na posição do spawner
            Instantiate(mothershipPrefab, transform.position, Quaternion.identity);

            // Reseta o tempo até o próximo spawn com um novo valor aleatório
            timeToNextSpawn = Random.Range(spawnMinTime, spawnMaxTime);
        }
    }
}
