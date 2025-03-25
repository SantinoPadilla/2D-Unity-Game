using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50;  // Salud del enemigo

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobamos si el enemigo colisiona con un shuriken
        if (collision.gameObject.CompareTag("Shuriken"))
        {
            // Llamamos a la función de daño
            TakeDamage(10);  // Ejemplo, el daño que causa el shuriken es 10
        }
    }

    // Función que reduce la salud del enemigo
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Si la salud llega a 0 o menos, destruimos al enemigo
        if (health <= 0)
        {
            Die();
        }
    }

    // Función que destruye al enemigo
    private void Die()
    {
        // Aquí podrías agregar efectos de muerte o animaciones si lo deseas
        Destroy(gameObject);  // Destruye al enemigo
    }
}
