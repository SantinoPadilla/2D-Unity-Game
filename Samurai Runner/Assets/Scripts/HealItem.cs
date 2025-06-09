using UnityEngine;

public class HealItem : MonoBehaviour
{
    public float amount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LifeBar lifeBar = collision.GetComponent<LifeBar>();

            if (lifeBar != null)
            {
                lifeBar.Heal(amount);
                Destroy(gameObject);
            }
        }
    }
}
