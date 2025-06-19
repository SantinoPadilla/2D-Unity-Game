using UnityEngine;

[RequireComponent(typeof(MovimientoJefe))]
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
        // Si toca al jugador, le hace daño
        if (collision.CompareTag("Player"))
        {
            LifeBar player = collision.GetComponent<LifeBar>();
            if (player != null)
            {
                player.RecibirDaño(danoAlJugador);
                Debug.Log("El jefe dañó al jugador");
            }
        }

        // Si lo toca una espada
        if (collision.CompareTag("Sword"))
        {
            RecibirDaño(3);
            Debug.Log("Jefe golpeado por espada");
        }
    }

    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;

        // Knockback
        if (movimientoJefe != null)
        {
            movimientoJefe.RecibirDanio(); // Usa el knockback del script MovimientoJefe
        }

        if (vida <= 0)
        {
            Debug.Log("Jefe derrotado");
            Destroy(gameObject);
        }
    }
}

