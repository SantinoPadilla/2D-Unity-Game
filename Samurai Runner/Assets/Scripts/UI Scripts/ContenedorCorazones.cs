using UnityEngine;
using UnityEngine.UI;

public class ContenedorCorazones : MonoBehaviour
{
    [SerializeField] private CorazonUI[] corazones;

    [SerializeField] private LifeBar lifeBar;

    private void Start()
    {
            lifeBar = GetComponent<LifeBar>();
    }
    private void ActivarCorazones(int vidaActual)
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (i < vidaActual)
            {
                corazones[i].ActivarCorazon();
            } 
            else
            {
                corazones[i].DesactivarCorazon();
            }
        }
    }
}
