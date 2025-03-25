using UnityEngine;

public class ShurikenBehavior : MonoBehaviour
{
    public float velocidad = 10f;
    public int dano = 1;
    public float tiempoVida = 2f;

    private Vector2 direccion;

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
        Debug.Log("Colisiona");
        if (collision.CompareTag("Enemy"))  // Detecta si choca con un enemigo
        {
            collision.GetComponent<Enemy>().RecibirDano(dano);  // Llama a un método del enemigo para recibir daño
            Destroy(gameObject);  // Destruye la shuriken al impactar
        }
        else if (!collision.CompareTag("Player"))  // Si choca con algo que no sea el player
        {
            Destroy(gameObject);  // Se destruye al impactar
        }
    }
}
