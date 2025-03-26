using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
    private Color originalColor;

    private PlayerMovement playerMovement;

    [SerializeField] private float slideDuration = 0.5f;
    [SerializeField] private Color slideColor = Color.red;

    private bool isSliding = false;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
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
        // Tamaño y offset relativo al collider original
        Vector2 slideColliderSize = new Vector2(originalColliderSize.x, originalColliderSize.y / 2);
        Vector2 slideColliderOffset = new Vector2(originalColliderOffset.x, -(originalColliderSize.y - slideColliderSize.y) / 2);

        // Configuración del slide
        boxCollider.size = slideColliderSize;
        boxCollider.offset = slideColliderOffset;
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


