using UnityEngine;

public class MovimientoJefe : MonoBehaviour
{
    public float velocidad = 2f; // Configurable desde el Inspector
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);
    }
}