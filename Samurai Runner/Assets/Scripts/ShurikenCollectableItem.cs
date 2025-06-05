using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenCollectableItem : MonoBehaviour
{
    public int amount = 1;
    private PlayerShuriken pS;
  
    private void Start()
    {
        pS = GetComponent<PlayerShuriken>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerShuriken pS = other.GetComponent<PlayerShuriken>();
            if (pS != null)
            {
                pS.AddShuriken(amount); 
                Destroy(gameObject); 
            }
        }

    }
}
