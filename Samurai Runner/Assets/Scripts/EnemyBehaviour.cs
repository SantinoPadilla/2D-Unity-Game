using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int vida = 3;

    public void RecibirDano(int cantidadDano)
    {
        vida -= cantidadDano;

        if (vida <= 0)
        {
            Destroy(gameObject);  // Destruye al enemigo cuando la vida llega a 0
        }
    }
}
