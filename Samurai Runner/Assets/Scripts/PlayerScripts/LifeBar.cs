using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LifeBar : MonoBehaviour
{
    public Image lifeBar;

    public float vidaMaxima;
    public float vidaActual;

    private SpriteRenderer spriteRenderer;
    private bool esInvulnerable = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        lifeBar.fillAmount = vidaActual / vidaMaxima;
    }
    public void RecibirDaño(int daño)
    {
        if (!esInvulnerable)
        {
            
            vidaActual -= daño;
            Debug.Log("Vida actual: " + vidaActual);

            if (vidaActual <= 0)
            {
                Debug.Log("¡Jugador muerto!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                StartCoroutine(EfectoInvulnerabilidad());
            }
        }
    }

    public void Heal(float amount)
    {
        vidaActual += amount;
    }
    private IEnumerator EfectoInvulnerabilidad()
    {
        esInvulnerable = true;

        // Titilar durante 1 segundo (0.1f segundos encendido y apagado)
        for (float i = 0; i < 1f; i += 0.2f)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        // Esperar el tiempo restante para completar los 2 segundos de invulnerabilidad
        yield return new WaitForSeconds(1f);

        esInvulnerable = false;
    }

}
