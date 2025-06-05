using UnityEngine;

public class ShurikenBehavior : MonoBehaviour
{
    public float velocidad = 10f;
    public int dañoEnemy = 1;
    public float tiempoVida = 2f;

    private Vector2 direccion = Vector2.zero;

    void Start()
    {
        Destroy(gameObject, tiempoVida);  // Destruir después de un tiempo para evitar objetos infinitos
    }

    public void Lanzar(Vector2 direccionLanzamiento)
    {
        direccion = direccionLanzamiento.normalized;
    }

    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);  // Movimiento en línea recta
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().RecibirDañoEnemy(dañoEnemy);
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}