using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                GameObject.Find("MyScore").GetComponent<Text>().text = Globals.m_coinscore.ToString();
                Destroy(transform.gameObject);
            }
        }      
    }
}
