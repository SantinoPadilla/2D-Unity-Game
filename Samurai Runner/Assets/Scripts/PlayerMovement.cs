using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    public float velocidadBase = 5f;
    public float incrementoVelocidad = 2f;
    public float velocidadActual;
    public float jumpForce = 10f;
    public bool canJump = true;
    public bool canBounce = false;
    private int direccion = 1; // 1 = derecha, -1 = izquierda
    private bool teclasRotadas = false;
    private float camSpeed;
    public bool pegadoAPared = false;
    public bool attacking;


    public Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Camera mainCamera;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        velocidadActual = velocidadBase;
        camSpeed = velocidadBase;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;

        animator.SetFloat("Movement", inputHorizontal * velocidadActual);
        animator.SetBool("Attacking", attacking);

        // Debug para ver qué tecla activa el ataque
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Click izquierdo → Espada");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Click derecho → Shuriken");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !attacking)
        {
            Attack();
        }
    }

    void FixedUpdate()
        {
            OnWall();
            MovimientoPlayer();
            Jump();
            OnWall();
            MoverCamara();

            float inputHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        }

    void ActualizarAnimaciones()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Movement", Mathf.Abs(inputHorizontal * velocidadActual));
        //animator.SetBool("Attacking", attacking);
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
                    spriteRenderer.flipX = false;
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
                    spriteRenderer.flipX = true;
                    velocidadActual = velocidadBase + incrementoVelocidad;
                }
                else if (inputHorizontal > 0) // Tecla D (Desacelera ahora)
                {
                    spriteRenderer.flipX = false;
                    velocidadActual = Mathf.Max(1f, velocidadBase - incrementoVelocidad);
                }
                else
                {
                    velocidadActual = velocidadBase;
                }
            }
        }


        void OnWall()
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

    // Función para saber si el jugador está mirando a la derecha (para el shuriken)
    public bool IsFacingRight()
    {
        return direccion == 1; // Si la dirección es 1, significa que está mirando a la derecha
    }

    public void Attack()
    {
       
        attacking = true;
    }

    public void AttackDisable()
    {
        attacking = false;
    }

}



