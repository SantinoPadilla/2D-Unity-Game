using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
    private Color originalColor;

    private PlayerMovement playerMovement;

    [SerializeField] private float slideScaleY = 0.5f;
    [SerializeField] private Color slideColor = Color.red;
    [SerializeField] private float slideDuration = 0.5f;

    private bool isSliding = false;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Asegúrate de referenciar el script de movimiento
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalColliderSize = boxCollider.size;
        originalColliderOffset = boxCollider.offset;
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        HandleSlide();
    }

    void HandleSlide()
    {
        if (Input.GetAxisRaw("Vertical") < 0 && !isSliding) // Inicia el slide si no está deslizando
        {
            isSliding = true;
            playerMovement.canJump = false;  // Desactiva el salto mientras se desliza
            StartCoroutine(SlideCoroutine());
        }
    }

    private System.Collections.IEnumerator SlideCoroutine()
    {
        // Configuración del slide
        boxCollider.size = new Vector2(originalColliderSize.x, slideScaleY);
        boxCollider.offset = new Vector2(originalColliderOffset.x, -(originalColliderSize.y - slideScaleY) / 2);
        spriteRenderer.color = slideColor;

        yield return new WaitForSeconds(slideDuration);

        // Restauración tras el slide
        boxCollider.size = originalColliderSize;
        boxCollider.offset = originalColliderOffset;
        spriteRenderer.color = originalColor;

        playerMovement.canJump = true;  // Restablece la capacidad de salto después del deslizamiento
        isSliding = false;
    }
}

