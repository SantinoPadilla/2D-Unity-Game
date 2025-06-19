using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidZone : MonoBehaviour
{
    public GameObject gameOverCanvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;

            gameOverCanvas.SetActive(true);
        }
    }

 
}
