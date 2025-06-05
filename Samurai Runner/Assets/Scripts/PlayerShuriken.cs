using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShuriken : MonoBehaviour
{
    public GameObject shurikenPrefab;  // Prefab del shuriken
    public float throwForce = 10f;     // Fuerza del lanzamiento
    public Transform launchPoint;      // Punto de lanzamiento
    public int shurikenAmount = 3;

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Obtener el script de movimiento
    }
    public void AddShuriken(int amount)
    {
        shurikenAmount += amount;
        Debug.Log("Shurikens: " + shurikenAmount);
    }
    void Update()
    {
        // Lanzar el shuriken con el botón derecho del ratón
        if (Input.GetKeyDown(KeyCode.Mouse1) && shurikenAmount > 0 ) // Mouse button 1 = click derecho
        {
            ThrowShuriken();
            shurikenAmount -= 1;    
        }
    }

    void ThrowShuriken()
    {
        
          
        // Instanciar el Shuriken en el punto de lanzamiento
        GameObject shuriken = Instantiate(shurikenPrefab, launchPoint.position, Quaternion.identity);

        // Obtener la dirección en la que el jugador está mirando (izquierda o derecha)
        float direction = playerMovement.IsFacingRight() ? 1f : -1f;

        // Obtener el Rigidbody2D del shuriken para agregarle velocidad
        Rigidbody2D rb = shuriken.GetComponent<Rigidbody2D>();

        // Lanzar el shuriken en la dirección correcta
        rb.linearVelocity = new Vector2(direction * throwForce, 0); // Lanzamiento horizontal

        

        
    }

    

    // Puedes tener otras cosas como lanzar shurikens, moverse, etc.

  
}



