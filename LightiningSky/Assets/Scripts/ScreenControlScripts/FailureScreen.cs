using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailureScreen : MonoBehaviour
{
    public Text m_failureSceentxt;
    public GameObject m_homeSceen;
    public GameObject m_playButton;
    public GameObject m_player;
    public Text m_instuctTxt;

    private void OnEnable()
    {
        

        Time.timeScale = 0;

        

        if (PlayerPrefs.GetInt("Score") != 0)
            score = PlayerPrefs.GetInt("Score");

        score = Globals.m_coinscore + score;
        PlayerPrefs.SetInt("Score", score);



        GameObject.Find("MyScore").GetComponent<Text>().text = "";
        //LevelController
        GameObject.Find("LevelController").GetComponent<SelectLevelScript>().enabled = false;

        GameObject.Find("GameView").transform.position = new Vector3(0, 0, 43);
        if (score < 10)
        {
            m_instuctTxt.text = "Not Enough Coins";
            m_playButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            m_playButton.GetComponent<Button>().interactable = true;
            m_instuctTxt.text = "";
        }

        if (PlayerPrefs.GetInt("Score") != 0)
        {
            m_failureSceentxt.text = "Score " + PlayerPrefs.GetInt("Score").ToString();
        }

    }

    public void GoHome()
    {
        Time.timeScale = 1;

        Globals.m_coinscore = 0;
        m_homeSceen.SetActive(true);
        m_player.SetActive(true);
        GameObject.Find("PlayerHealthbar").GetComponent<Slider>().value = 100;
        GameObject.Find("GameView").transform.position = new Vector3(80, 80, 80);
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
        this.gameObject.SetActive(false);
    }


    public void RestartLevelFromFirst()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        m_player.SetActive(true);
        PlayerShooting[] playerShootings = m_player.GetComponentsInChildren<PlayerShooting>();
        foreach (PlayerShooting playerShooting in playerShootings)
        {
            playerShooting.Start();
        }
        Globals.m_coinscore = 0;
        GameObject.Find("PlayerHealthbar").GetComponent<Slider>().value = 100;
        GameObject.Find("GameView").transform.position = new Vector3(0, 0, 0);
        if (Globals.m_currentLvl != null)
        {

            Globals.m_currentLvl.GetComponent<LevelScript>().Start();
            
            GameObject.Find("LevelController").GetComponent<SelectLevelScript>().enabled = true;
            
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

    int score = 0;
    public void ResumeGame()
    {
        Time.timeScale = 1;
       
        m_player.SetActive(true);

        Globals.m_coinscore = 0;
        PlayerShooting[] playerShootings = m_player.GetComponentsInChildren<PlayerShooting>();
        foreach (PlayerShooting playerShooting in playerShootings)
        {
            playerShooting.Start();
        }

        GameObject.Find("PlayerHealthbar").GetComponent<Slider>().value = 100;
        GameObject.Find("GameView").transform.position = new Vector3(0, 0, 0);
        this.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("Score") != 0)
            score = PlayerPrefs.GetInt("Score");

        score -= 10;

        PlayerPrefs.SetInt("Score", score);

    }

}
