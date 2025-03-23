using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public TMP_Text lifeTotalText;

    public GameObject invadersParent;

    [SerializeField] private int score = 0;
    [SerializeField] private int lifeTotal = 3;

    public static void AddScore(int points)
    {
        if (instance != null)
        {
            instance.score += points;
        }
    }

    public static void LostLife()
    {
        if (instance != null)
        {
            instance.lifeTotal -= 1;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "SCORE: " + score.ToString() + " pts";
        lifeTotalText.text = lifeTotal.ToString();
    }

    void Update()
    {
        scoreText.text = "SCORE: " + score.ToString() + " pts";
        lifeTotalText.text = lifeTotal.ToString();
    }

    void LateUpdate()
    {
        bool existemInvaders = invadersParent.transform.childCount > 0;

        if (lifeTotal <= 0 && existemInvaders)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (lifeTotal > 0 && !existemInvaders)
        {
            SceneManager.LoadScene("Victory");
        }
    }

}
