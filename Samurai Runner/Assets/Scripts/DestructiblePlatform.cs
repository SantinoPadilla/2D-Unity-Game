using UnityEngine;
using System.Collections;

public class DestructiblePlatform : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 2f;   // Tiempo antes de destruirse
    [SerializeField] private float blinkInterval = 0.2f; // Intervalo de parpadeo

    private bool isTriggered = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            StartCoroutine(BlinkBeforeDestruction()); // Inicia el parpadeo y la destrucción
        }
    }

    private IEnumerator BlinkBeforeDestruction()
    {
        float elapsed = 0f;

        while (elapsed < destroyDelay)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled; // Parpadeo del sprite
            yield return new WaitForSeconds(blinkInterval);
            elapsed += blinkInterval;
        }

        Destroy(gameObject); // Destruir plataforma
    }
}

