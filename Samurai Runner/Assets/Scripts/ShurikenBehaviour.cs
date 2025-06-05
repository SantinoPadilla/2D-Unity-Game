using UnityEngine;

public class ShurikenBehavior : MonoBehaviour
{
    public float velocidad = 10f;
    public int da�oEnemy = 1;
    public float tiempoVida = 2f;

    private Vector2 direccion = Vector2.zero;

    void Start()
    {
        Destroy(gameObject, tiempoVida);  // Destruir despu�s de un tiempo para evitar objetos infinitos
    }

    public void Lanzar(Vector2 direccionLanzamiento)
    {
        direccion = direccionLanzamiento.normalized;
    }

    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);  // Movimiento en l�nea recta
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().RecibirDa�oEnemy(da�oEnemy);
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}