
using UnityEngine;

public class CameraAutoScroll : MonoBehaviour
{
    public float velocidadCamaraX = 5f;    // Velocidad constante de la cámara en el eje X
    public float velocidadCamaraY = 5f;    // Velocidad constante de la cámara en el eje Y

    public Transform player;

    public float minY = -2f;               // Límite mínimo vertical
    public float maxY = 5f;                // Límite máximo vertical
    

    void Start()
    {
   
    }

    void Update()
    {
        // Movimiento constante hacia la derecha (solo eje X)
        transform.position += Vector3.right * velocidadCamaraX * Time.deltaTime;

        transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
    }

   
}