using UnityEngine;

public class PlayerShuriken : MonoBehaviour
{
    public GameObject shurikenPrefab;  // Prefab del shuriken
    public float throwForce = 10f;     // Fuerza del lanzamiento
    public Transform launchPoint;      // Punto de lanzamiento

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Obtener el script de movimiento
    }

    void Update()
    {
        Debug.Log("Shuriken script activo"); // ⬅️ Este ahora sí se verá

        if (Input.GetKeyDown(KeyCode.Mouse1)) // click derecho
        {
            Debug.Log("Click derecho → intento lanzar shuriken");
            ThrowShuriken();
        }
    }

    void ThrowShuriken()
    {
        if (playerMovement.attacking) return; // No lanzar si está atacando con espada

        GameObject shuriken = Instantiate(shurikenPrefab, launchPoint.position, Quaternion.identity);

        float direction = playerMovement.IsFacingRight() ? 1f : -1f;

        Rigidbody2D rb = shuriken.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(direction * throwForce, 0);

        Debug.Log("Shuriken lanzado");
    }
}




