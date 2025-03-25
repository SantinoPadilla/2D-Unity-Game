using UnityEngine;

public class ShurikenDmg : MonoBehaviour
{
    public int damage = 10;  // Da�o que hace el shuriken al enemigo

    // Se llama cuando el shuriken colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto con el que colision� tiene el tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Obtiene el componente EnemyHealth del objeto al que ha colisionado
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Aplica el da�o al enemigo
                enemyHealth.TakeDamage(damage);
            }

            // Destruye el shuriken despu�s de la colisi�n
            Destroy(gameObject);
        }
    }
}


