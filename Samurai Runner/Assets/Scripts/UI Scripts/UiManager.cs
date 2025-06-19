using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;

    public void Pausa()
    {
        Time.timeScale = 0f;
        buttonPause.SetActive(false);
        menuPause.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
    }

    public void QuitGame() { 
    
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MapScene");
    }
}
