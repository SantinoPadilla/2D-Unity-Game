using UnityEngine;

public class ShurikenDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobamos si el shuriken colisiona con el enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Llamamos a la función de daño en el enemigo (se hace directamente desde el enemigo)
            Destroy(gameObject); // Elimina el shuriken después de colisionar
        }
    }
}

