using UnityEngine;

public class ShurikenDmg : MonoBehaviour
{
    public int damage = 10;  // Daño que hace el shuriken al enemigo

    // Se llama cuando el shuriken colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto con el que colisionó tiene el tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Obtiene el componente EnemyHealth del objeto al que ha colisionado
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Aplica el daño al enemigo
                enemyHealth.TakeDamage(damage);
            }

            // Destruye el shuriken después de la colisión
            Destroy(gameObject);
        }
    }
}


