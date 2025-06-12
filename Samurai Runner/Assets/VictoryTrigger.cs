using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    public GameObject victoryCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            victoryCanvas.SetActive(true);
        }
    }
}

