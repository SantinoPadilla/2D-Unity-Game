using UnityEngine;

public class Pinche : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LifeBar lifeBar = collision.GetComponent<LifeBar>();

            if (lifeBar != null)
            {
                lifeBar.RecibirDaño(damage);
            }
        }
    }
}
