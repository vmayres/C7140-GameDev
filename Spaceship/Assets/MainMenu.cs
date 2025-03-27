using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMEnu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
