using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
    private Color originalColor;

    [SerializeField] private float slideScaleY = 0.5f;
    [SerializeField] private Color slideColor = Color.red;

    void Start()
    {
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
        if (Input.GetAxisRaw("Vertical") < 0) // Cuando se presiona abajo
        {
            boxCollider.size = new Vector2(originalColliderSize.x, slideScaleY);
            boxCollider.offset = new Vector2(originalColliderOffset.x, -(originalColliderSize.y - slideScaleY) / 2);
            spriteRenderer.color = slideColor;
        }
        else // Cuando se deja de presionar abajo
        {
            boxCollider.size = originalColliderSize;
            boxCollider.offset = originalColliderOffset;
            spriteRenderer.color = originalColor;
        }
    }
}

