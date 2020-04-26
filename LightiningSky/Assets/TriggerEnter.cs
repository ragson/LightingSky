using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
   
    // player Gaining Coin Score when Coin get hit to player
    //
    private void OnTriggerEnter(Collider other)
    {
        if (transform.name.Contains("coin"))
        {
            if (other.name == "Player")
            {
                
                Globals.m_coinscore++;
                
                Destroy(transform.gameObject);
            }
        }      
    }
}
