using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int daño = 1;
    public int vida = 3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LifeBar player = collision.GetComponent<LifeBar>();
            if (player != null)
            {
                player.RecibirDaño(daño);
                Debug.Log("¡Player recibió daño del enemigo!");
            }
        }
        if (collision.CompareTag("Sword"))
        {
            RecibirDañoEnemy(1);
            Debug.Log("Enemigo cortado");
        }


    }
  



    public void RecibirDañoEnemy(int cantidadDano)
    {
        vida -= cantidadDano;
        

        if (vida <= 0)
        {
            Destroy(gameObject);  // Destruye al enemigo cuando la vida llega a 0
        }
    }
}
