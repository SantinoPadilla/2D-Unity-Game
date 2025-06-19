using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{
    public void ReturnToMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }
}

