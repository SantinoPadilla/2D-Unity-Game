using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para manejar escenas

public class VoidZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RestartLevel(); // Reinicia el nivel si el jugador cae
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual
    }
}

