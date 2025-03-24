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
    public bool canBounce = false;
    private int direccion = 1; // 1 = derecha, -1 = izquierda
    private bool teclasRotadas = false;

    public Camera mainCamera;
    private float camSpeed;
    public bool pegadoAPared = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        velocidadActual = velocidadBase;
        camSpeed = velocidadBase;

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        MovimientoPlayer();
        Jump();
        MoverCamara();
    }

    void FixedUpdate()
    {
        if (!pegadoAPared)
        {
            rb.linearVelocity = new Vector2(velocidadActual * direccion, rb.linearVelocity.y);
        }
        else if (rb.linearVelocity.y < 0 && !canJump) // Si está pegado a la pared y cayendo, reducir la caída
        {
            rb.linearVelocity = new Vector2(0, -2f); // Controlar la velocidad de caída al estar pegado
        }
    }

    void MovimientoPlayer()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");

        if (!teclasRotadas)  // Movimiento normal
        {
            if (inputHorizontal < 0) // Tecla A (Desacelera)
            {
                velocidadActual = Mathf.Max(1f, velocidadBase - incrementoVelocidad);
            }
            else if (inputHorizontal > 0) // Tecla D (Acelera)
            {
                velocidadActual = velocidadBase + incrementoVelocidad;
            }
            else
            {
                velocidadActual = velocidadBase;
            }
        }
        else  // Movimiento invertido
        {
            if (inputHorizontal < 0) // Tecla A (Acelera ahora)
            {
                velocidadActual = velocidadBase + incrementoVelocidad;
            }
            else if (inputHorizontal > 0) // Tecla D (Desacelera ahora)
            {
                velocidadActual = Mathf.Max(1f, velocidadBase - incrementoVelocidad);
            }
            else
            {
                velocidadActual = velocidadBase;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            pegadoAPared = false;
        }

        if (collision.gameObject.CompareTag("BounceW"))
        {
            pegadoAPared = true;
            canBounce = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BounceW"))
        {
            pegadoAPared = false;
            canBounce = false;
            canJump = false;
        }
    }

    void Jump()
    {
        if (pegadoAPared && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            WallBounce(); // Cambia la dirección solo al saltar
            pegadoAPared = false;
            canJump = false; // Desactiva el salto hasta tocar el suelo
        }
        else if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void WallBounce()
    {
        // Cambia la dirección del player y la cámara
        direccion *= -1;
        teclasRotadas = !teclasRotadas;
        camSpeed = Mathf.Abs(camSpeed) * direccion;
    }

    void MoverCamara()
    {
        Vector3 nuevaPosicion = mainCamera.transform.position;
        nuevaPosicion.x += camSpeed * Time.deltaTime;
        mainCamera.transform.position = nuevaPosicion;
    }
}



