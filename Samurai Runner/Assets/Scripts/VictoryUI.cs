using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{
    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Reactiva el tiempo por si está pausado
        SceneManager.LoadScene("MainMenu"); // Reemplazá con el nombre exacto de tu escena del menú
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game called (doesn't close in Editor)");
    }
}

