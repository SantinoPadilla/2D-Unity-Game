using UnityEngine;

public class ShurikenEnemigo : MonoBehaviour
{
    public float velocidad;

    public int daño;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * velocidad * -Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out LifeBar vidaJugador))
        {
            vidaJugador.RecibirDaño(daño);
        }
    }
}
