using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public GameObject boss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            boss.SetActive(true);
            Destroy(gameObject); // Opcional: eliminar el trigger
        }
    }
}