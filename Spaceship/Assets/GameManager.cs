using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public FuelBar fuelBar;  // Referência ao script FuelBar
    public GameObject heartContainer;  // Referência ao HeartContainer
    public TextMeshProUGUI ammoText; // Texto da munição na UI

    // Vida do jogador
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;

    // Muniçao do jogador
    [SerializeField] private int maxAmmo = 50;
    private int currentAmmo;

    // Controle da Barra de conbustivel.
    public float fuelDecreaseRate = 1f;  // Quantidade de combustível a ser diminuída a cada segundo
    [SerializeField] public float speedMultiplier = 1f;  // Multiplicador de velocidade (1x é a velocidade normal)
    [SerializeField] public float maxSpeedMultiplier = 5f;  // Multiplicador máximo de velocidade
    [SerializeField] private float timeWithoutDamage = 0f;  // Tempo que o jogador está sem tomar dano

    public TextMeshProUGUI distanceText; // Texto de distância no Canvas

    private float distanceTraveled = 0f; // Distância total percorrida
    public float distanceSpeedFactor = 100f; // Fator base de velocidade de contagem


    void Start()
    {
        if (fuelBar != null)
            fuelBar.RefillFuel(100f);

        currentHealth = maxHealth;
        UpdateHealthDisplay();

        currentAmmo = maxAmmo;
        UpdateAmmoDisplay();
    }

    void Update()
    {
        IncreaseTimeWithoutDamage(Time.deltaTime);

        // Atualiza distância percorrida baseada no speedMultiplier
        distanceTraveled += speedMultiplier * distanceSpeedFactor * Time.deltaTime;
        UpdateDistanceText();


        if (fuelBar != null && fuelBar.currentFuel > 0)
        {
            fuelBar.ConsumeFuel(fuelDecreaseRate * Time.deltaTime);
        }
        else
        {
            Debug.Log("Game Over: Out of Fuel");
        }

        float newMultiplier = Mathf.Min(maxSpeedMultiplier, 1 + (timeWithoutDamage / 50f));

        if (Mathf.Abs(newMultiplier - speedMultiplier) > 0.01f)
        {
            speedMultiplier = newMultiplier;
        }
    }

    void UpdateDistanceText()
    {
        if (distanceText != null)
        {
            string distanciaFormatada = distanceTraveled.ToString("0.#####E+0");
            distanceText.text = $"Distance: {distanciaFormatada} km";
        }
    }


    // Tempo em que o jogardior ficou sem tomar dano.
    public void IncreaseTimeWithoutDamage(float deltaTime)
    {
        if (currentHealth > 0)
        {
            timeWithoutDamage += deltaTime;
        }
    }


    // Gerenciamento de Vida do player
    public void TakeDamage(int damage) // Reber dano e perde vida
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Game Over: No Health");
        }

        UpdateHealthDisplay();
        timeWithoutDamage = 0f;
    }

    public void IncreaseHealth(int heal) // Recebendo cura
    {
        if (currentHealth >= maxHealth)
        {
            // vida maxima (nao fazer nada)
        }
        else
        {
            if ( (currentHealth + heal) >= maxHealth) 
            { 
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += heal;
            }

        }

        UpdateHealthDisplay();

    }

    void UpdateHealthDisplay() // Atualiza o display de vida
    {
        for (int i = 1; i <= maxHealth; i++)
        {
            Transform heart = heartContainer.transform.Find("Heart" + i);
            if (heart != null)
            {
                heart.gameObject.SetActive(i <= currentHealth);
            }
        }
    }

    // Gerenciamneto de Municao do jogador.
    public bool UseAmmo() // Remove muniçao
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            UpdateAmmoDisplay();
            return true;
        }
        return false;
    }

    public void AddAmmo(int amount) // adiciona muniçao
    {
        currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
        UpdateAmmoDisplay();
    }

    void UpdateAmmoDisplay() // Atuliza o display da municao
    {
        if (ammoText != null)
        {
            ammoText.text = currentAmmo.ToString();
        }
    }
}
