using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidadBase = 5f;
    public float incrementoVelocidad = 2f;
    private Rigidbody2D rb;
    public float velocidadActual;
    public float jumpForce = 10f;
    public bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        velocidadActual = velocidadBase;
    }

    void Update()
    {
        MovimientoPlayer();
        Jump();
    }

    void FixedUpdate()
    {
        // Movimiento constante hacia la derecha
        rb.linearVelocity = new Vector2(velocidadActual, rb.linearVelocity.y);
    }

    void MovimientoPlayer()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");

        if (inputHorizontal < 0) // Tecla A o Flecha Izquierda
        {
            velocidadActual = Mathf.Max(1f, velocidadBase - incrementoVelocidad);
        }
        else if (inputHorizontal > 0) // Tecla D o Flecha Derecha
        {
            velocidadActual = velocidadBase + incrementoVelocidad;
        }
        else
        {
            velocidadActual = velocidadBase;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el personaje toca el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; // El personaje puede saltar cuando toca el suelo
        }
    }

    void Jump()
    {
        // Verifica si el jugador ha presionado la tecla de salto (Espacio)
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false; // Después de saltar, desactivamos la capacidad de saltar hasta que toque el suelo
        }
    }
}




