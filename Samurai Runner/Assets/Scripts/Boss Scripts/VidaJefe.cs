using UnityEngine;

[RequireComponent(typeof(MovimientoJefe))]
public class VidaJefe : MonoBehaviour
{
    public int vidaMaxima = 3;
    private int vidaActual;

    private MovimientoJefe movimientoJefe;

    void Start()
    {
        vidaActual = vidaMaxima;
        movimientoJefe = GetComponent<MovimientoJefe>();
    }

    public void RecibirDaño()
    {
        vidaActual--;
        Debug.Log("Jefe recibió daño. Vida restante: " + vidaActual);

        movimientoJefe.RecibirDanio(); 
        // Knockback

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("Jefe derrotado");
        Destroy(gameObject);
    }
}

