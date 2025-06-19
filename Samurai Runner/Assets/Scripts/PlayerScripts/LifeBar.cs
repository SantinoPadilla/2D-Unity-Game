using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LifeBar : MonoBehaviour
{

    [SerializeField] private CorazonUI[] corazones;
    public float vidaMaxima;
    public float vidaActual;

    private SpriteRenderer spriteRenderer;
    private bool esInvulnerable = false;

    [SerializeField] AudioSource audioSource;
    [SerializeField] public AudioClip ouchAudioClip;
    [SerializeField] public AudioClip healAudioClip;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        ActivarCorazones(vidaActual);
    }


    private void ActivarCorazones(float vidaActual)
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (i < vidaActual)
            {
                corazones[i].ActivarCorazon();
            }
            else
            {
                corazones[i].DesactivarCorazon();
            }
        }
    }

    public GameObject gameOverCanvas;
    public void RecibirDaño(int daño)
    {
        if (!esInvulnerable)
        {
            audioSource.PlayOneShot(ouchAudioClip);
            vidaActual -= daño;
            

            if (vidaActual <= 0)
            {
                Time.timeScale = 0f;

                gameOverCanvas.SetActive(true);
            }
            else
            {
                StartCoroutine(EfectoInvulnerabilidad());
            }
        }
    }

    public void Heal(float amount)
    {
        audioSource.PlayOneShot(healAudioClip);
        if (vidaActual == vidaMaxima)
        {
           amount = 0;
        }
        else
        {
            vidaActual += amount;
        }
        
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
