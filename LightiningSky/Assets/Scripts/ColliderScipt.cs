using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderScipt : MonoBehaviour
{
     Slider m_healthbar;

    private void Awake()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")//Enemy layer index
        {
            m_healthbar = collision.collider.transform.GetChild(0).GetChild(0).GetComponent<Slider>();
            if(!m_healthbar.gameObject.activeSelf)
            m_healthbar.gameObject.SetActive(true);

            m_healthbar.value -= 1;

            if (m_healthbar.value == 0)
            {
                Destroy(collision.collider.gameObject);
               // Destroy(this.gameObject);
                if (collision.collider.name.Contains("Enemy4"))
                {
                    Globals.Enemy4DstrCnt++;
                }

                if (collision.collider.name.Contains("BossEnemyHolder"))
                {
                    Globals.bosslesslevedstryCnt++;
                }
            }
        }

        if (collision.collider.name == "Player")
        {
            GameObject.Find("PlayerHealthbar").GetComponent<Slider>().value -= 5;
            if(GameObject.Find("PlayerHealthbar").GetComponent<Slider>().value==0)
            Destroy(collision.collider.gameObject);
        }

        if (collision.collider.tag == "Bullet")
        {
            collision.collider.GetComponent<SpriteRenderer>().enabled = false;
        }
      //  else
       // Destroy(this.gameObject);
    }

}
