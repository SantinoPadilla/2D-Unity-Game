using UnityEngine;

public class PlayerShuriken : MonoBehaviour
{
    public GameObject shurikenPrefab;  // Prefab del shuriken
    public float throwForce = 10f;     // Velocidad del lanzamiento
    public Transform launchPoint;      // Punto de lanzamiento
    public int shurikenAmount = 3;

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Obtener el script de movimiento
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && shurikenAmount > 0 ) // Click derecho
        {
            if (playerMovement.attacking) return; // No lanzar si está atacando

            GameObject shuriken = Instantiate(shurikenPrefab, launchPoint.position, Quaternion.identity);

            float direction = playerMovement.IsFacingRight() ? 1f : -1f;
            Vector2 directionVector = new Vector2(direction, 0);

            // Llamar al método de movimiento en el shuriken
            shuriken.GetComponent<ShurikenBehavior>().Lanzar(directionVector);
            shurikenAmount -= 1;
        }
    }

    public void AddShuriken(int amount)
    {
        shurikenAmount += amount;

        Debug.Log("Shurikens: " + shurikenAmount);
    }
}