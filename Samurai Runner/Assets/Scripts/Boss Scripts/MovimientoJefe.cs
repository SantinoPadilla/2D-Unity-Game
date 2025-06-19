using UnityEngine;

public class MovimientoJefe : MonoBehaviour
{
    public float velocidad = 2f;
    private Rigidbody2D rb;
    private bool estaRecibiendoDanio = false;

    [Header("Knockback Configurable")]
    public Vector2 direccionKnockback = new Vector2(-1, 1);
    public float fuerzaKnockback = 6f;
    public float duracionKnockback = 0.3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!estaRecibiendoDanio)
        {
            rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);
        }
    }

    public void RecibirDanio()
    {
        estaRecibiendoDanio = true;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direccionKnockback.normalized * fuerzaKnockback, ForceMode2D.Impulse);
        Invoke(nameof(ReanudarMovimiento), duracionKnockback);
    }

    void ReanudarMovimiento()
    {
        estaRecibiendoDanio = false;
    }
}