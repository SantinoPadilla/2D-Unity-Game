using UnityEngine;

public class Jefe : MonoBehaviour
{
    public int vida = 5;
    public int danoAlJugador = 1;

    private MovimientoJefe movimientoJefe;

    private void Start()
    {
        movimientoJefe = GetComponent<MovimientoJefe>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Daño al jugador
        if (collision.CompareTag("Player"))
        {
            LifeBar player = collision.GetComponent<LifeBar>();
            if (player != null)
            {
                player.RecibirDaño(danoAlJugador);
                
            }
        }

        // Daño por espada
        if (collision.CompareTag("Sword"))
        {
            RecibirDañoEnemy(3);
            
        }

        // Daño por shuriken
        if (collision.CompareTag("Shuriken"))
        {
            RecibirDañoEnemy(1);
            
        }
    }

    public void RecibirDañoEnemy(int cantidadDano)
    {
        vida -= cantidadDano;

        if (movimientoJefe != null)
        {
            movimientoJefe.RecibirDanio(); // Knockback
        }

        

        if (vida <= 0)
        {
            Debug.Log("¡Jefe eliminado!");
            Destroy(gameObject);
        }
    }
}