using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int da�o = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LifeBar player = collision.GetComponent<LifeBar>();
            if (player != null)
            {
                player.RecibirDa�o(da�o);
                Debug.Log("�Player recibi� da�o del enemigo!");
            }
        }
    }

    public int vida = 3;

    public void RecibirDa�oEnemy(int cantidadDano)
    {
        vida -= cantidadDano;

        if (vida <= 0)
        {
            Destroy(gameObject);  // Destruye al enemigo cuando la vida llega a 0
        }
    }
}
