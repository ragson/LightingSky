using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessScreen : MonoBehaviour
{
    public Text m_successTxt;
    public GameObject m_homeScreen;
    public GameObject m_winEffect;
    public GameObject m_player;

    private void OnEnable()
    {

        if (PlayerPrefs.GetInt("Score") != 0)
        {
            m_successTxt.text = "Score " + PlayerPrefs.GetInt("Score").ToString();
        }

        GameObject.Find("LevelController").GetComponent<SelectLevelScript>().enabled = false;
       
        GameObject.Find("GameView").transform.position = new Vector3(80, 80, 80);
        m_player.SetActive(false);
        m_winEffect.SetActive(true);
        StartCoroutine(StopWinEffect());
    }

    IEnumerator StopWinEffect()
    {
        yield return new WaitForSeconds(6f);

        m_winEffect.SetActive(false);
    }


    public void GoHome()
    {
        m_homeScreen.SetActive(true);
        this.gameObject.SetActive(false);
        m_player.SetActive(true);
        GameObject.Find("PlayerHealthbar").GetComponent<Slider>().value = 100;
       // GameObject.Find("GameView").transform.position = new Vector3(0, 0, 43);
        PlayerShooting[] playerShootings = m_player.GetComponentsInChildren<PlayerShooting>();
        foreach (PlayerShooting playerShooting in playerShootings)
        {
            playerShooting.Start();
        }


        if (Globals.m_currentLvl != null)
        {
            Globals.m_currentLvl.GetComponent<LevelScript>().Start();
            GameObject.Find("LevelController").GetComponent<SelectLevelScript>().enabled = false;
            Globals.m_currentLvl.GetComponent<LevelScript>().m_1stWaveObjinfo.m_oneTimeInstiate = false;
            Globals.m_currentLvl.GetComponent<LevelScript>().m_2ndWaveObjInfo.m_oneTimeInstiate = false;
            Globals.m_currentLvl.GetComponent<LevelScript>().m_3rdWaveObjInfo.m_oneTimeInstiate = false;
            Globals.m_currentLvl.GetComponent<LevelScript>().m_4thWaveObjInfo.m_oneTimeInstiate = false;
            Globals.m_currentLvl.GetComponent<LevelScript>().m_5thWaveObjInfo.m_oneTimeInstiate = false;
            Globals.m_currentLvl.GetComponent<LevelScript>().m_5thWaveObjInfo.m_tempObjCnt = 0;
            Globals.m_currentLvl.GetComponent<LevelScript>().m_4thWaveObjInfo.m_tempObjCnt = 0;
            Globals.m_currentLvl.GetComponent<LevelScript>().m_3rdWaveObjInfo.m_tempObjCnt = 0;
            Globals.m_currentLvl.GetComponent<LevelScript>().m_2ndWaveObjInfo.m_tempObjCnt = 0;
            Globals.m_currentLvl.GetComponent<LevelScript>().m_1stWaveObjinfo.m_tempObjCnt = 0;

        }
    }
}
