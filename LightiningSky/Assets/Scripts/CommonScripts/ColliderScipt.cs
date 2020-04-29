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
            if (!m_healthbar.gameObject.activeSelf)
                m_healthbar.gameObject.SetActive(true);

            m_healthbar.value -= 1;



            if (m_healthbar.value == 0)
            {
                AudioSource audioSource = GameObject.Find("GainObjects").GetComponent<AudioSource>();
                audioSource.PlayOneShot(GameObject.Find("GainObjects").GetComponent<GainObjectController>().m_explosionClip);
                Expolsion(collision);


                //  GameObject explosion = Instantiate(GameObject.Find("GainObjects").GetComponent<GainObjectController>().m_explosion, collision.collider.transform.position, Quaternion.identity);
                GameObject m_coin = Instantiate(GameObject.Find("GainObjects").GetComponent<GainObjectController>().m_coinPrefab, collision.collider.transform.position, Quaternion.identity);
                m_coin.AddComponent<DestoyAfterCross>();
                if (collision.collider.name.Contains("Enemy4"))
                {
                    if (Globals.enemy4List.Count > 0)
                    {
                        Globals.enemy4List.Remove(collision.collider.gameObject);
                    }
                    Destroy(collision.collider.gameObject);

                }
                else
                if (collision.collider.name.Contains("BossEnemyHolder"))//after Boss Enemy Plane Success screen displayed
                {
                    int pastscore = 0;


                    // StopAllCoroutines();
                    Destroy(collision.collider.gameObject);
                    if (PlayerPrefs.GetInt("Score") != 0)
                        pastscore = PlayerPrefs.GetInt("Score");

                    if (Globals.m_coinscore > pastscore)
                        PlayerPrefs.SetInt("Score", Globals.m_coinscore);
                    else
                        PlayerPrefs.SetInt("Score", pastscore);
                    //  StartCoroutine(Expolsion(collision, "success"));

                    //

                    GameObject.Find("ScreenController").GetComponent<SceenControl>().m_successScreenPage.SetActive(true);
                }
                else
                {
                    Destroy(collision.collider.gameObject);
                }

            }
        }

        if (collision.collider.name == "Player")//if player gets hits to bullets and health loss failue sceen wll shown
        {

            GameObject.Find("PlayerHealthbar").GetComponent<Slider>().value -= 5;
            if (GameObject.Find("PlayerHealthbar").GetComponent<Slider>().value == 0)
            {
                // Destroy(collision.collider.gameObject);


                AudioSource audioSource = GameObject.Find("GainObjects").GetComponent<AudioSource>();
                audioSource.PlayOneShot(GameObject.Find("GainObjects").GetComponent<GainObjectController>().m_explosionClip);

                collision.collider.gameObject.SetActive(false);
                int pastscore = 0;
                if (PlayerPrefs.GetInt("Score") != 0)
                    pastscore = PlayerPrefs.GetInt("Score");

                if (Globals.m_coinscore > pastscore)
                    PlayerPrefs.SetInt("Score", Globals.m_coinscore);
                else
                    PlayerPrefs.SetInt("Score", pastscore);

               // StartCoroutine(Failue());
                //  StartCoroutine(Expolsion(collision, "failure"));
                //  
                GameObject.Find("ScreenController").GetComponent<SceenControl>().m_failureScreen.SetActive(true);
            }

        }

        if (collision.collider.tag == "Bullet")//if it get hits any thing it will destoy despite from ignore layer collisions
        {
            Destroy(collision.collider.gameObject);
        }
    }

    public void Expolsion(Collision collision)
    {
        GameObject explosion = Instantiate(GameObject.Find("GainObjects").GetComponent<GainObjectController>().m_explosion, collision.collider.transform.position, Quaternion.identity);
        explosion.AddComponent<DestroyBulletItself>();
        explosion.GetComponent<DestroyBulletItself>().m_timeAfterDestroy = 0.5f;
    }
}
