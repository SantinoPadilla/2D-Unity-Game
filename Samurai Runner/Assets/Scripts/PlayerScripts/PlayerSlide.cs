using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    private CapsuleCollider2D capsuleCollider;
    private SpriteRenderer spriteRenderer;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
   

    private PlayerMovement playerMovement;

    [SerializeField] private float slideScaleY = 0.5f;
   
    [SerializeField] private float slideDuration = 0.5f;

    private bool isSliding = false;

     public Animator animator;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Asegúrate de referenciar el script de movimiento
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalColliderSize = capsuleCollider.size;
        originalColliderOffset = capsuleCollider.offset;
     
    }

    void Update()
    {
        HandleSlide();
        animator.SetBool("IsSliding", isSliding);   
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
        capsuleCollider.size = new Vector2(originalColliderSize.x, slideScaleY);
        capsuleCollider.offset = new Vector2(originalColliderOffset.x, -(originalColliderSize.y - slideScaleY) / 2);
       

        yield return new WaitForSeconds(slideDuration);

        // Restauración tras el slide
        capsuleCollider.size = originalColliderSize;
        capsuleCollider.offset = originalColliderOffset;
      

        playerMovement.canJump = true;  // Restablece la capacidad de salto después del deslizamiento
        isSliding = false;
    }
}

