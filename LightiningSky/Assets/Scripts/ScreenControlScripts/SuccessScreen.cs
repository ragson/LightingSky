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
   public Button lvl1, lvl2, lvl3, lvl4, lvl5;
    public GameObject m_intoPLAYER;

    private void OnEnable()
    {
        int score = 0;
        if (PlayerPrefs.GetInt("Score") != 0)
            score = PlayerPrefs.GetInt("Score");

        score = Globals.m_coinscore + score;
        PlayerPrefs.SetInt("Score", score);

        if (PlayerPrefs.GetInt("Score") != 0)
        {
            m_successTxt.text = "Score " + PlayerPrefs.GetInt("Score").ToString();
        }

        //PlayerPrefs.SetInt("Score", Globals.m_coinscore);

        GameObject.Find("LevelController").GetComponent<SelectLevelScript>().enabled = false;
        GameObject.Find("MyScore").GetComponent<Text>().text = "";
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
       // m_intoPLAYER.transform.position = new Vector3(-2, -145, -320);
        Globals.m_coinscore = 0;
        GameObject.Find("PlayerHealthbar").GetComponent<Slider>().value = 100;
       // GameObject.Find("GameView").transform.position = new Vector3(0, 0, 43);
        PlayerShooting[] playerShootings = m_player.GetComponentsInChildren<PlayerShooting>();
        foreach (PlayerShooting playerShooting in playerShootings)
        {
            playerShooting.Start();
        }


        if (Globals.m_commonLvl != null)
        {
            Globals.m_commonLvl.GetComponent<LevelScript>().Start();
            DestroyImmediate(GameObject.Find("LevelController").GetComponent<SelectLevelScript>());
            GameObject.Find("LevelController").AddComponent<SelectLevelScript>();





            
            lvl1.onClick.AddListener(() => GameObject.Find("LevelController").GetComponent<SelectLevelScript>().Selectlevel(1));
           
            lvl2.onClick.AddListener(() => GameObject.Find("LevelController").GetComponent<SelectLevelScript>().Selectlevel(2));
           
            lvl3.onClick.AddListener(() => GameObject.Find("LevelController").GetComponent<SelectLevelScript>().Selectlevel(3));
           
            lvl4.onClick.AddListener(() => GameObject.Find("LevelController").GetComponent<SelectLevelScript>().Selectlevel(4));
            
            lvl5.onClick.AddListener(() => GameObject.Find("LevelController").GetComponent<SelectLevelScript>().Selectlevel(5));

            //GameObject.Find("LevelController").GetComponent<SelectLevelScript>().enabled = false;
            Globals.m_commonLvl.GetComponent<LevelScript>().m_1stWaveObjinfo.m_oneTimeInstiate = false;
            Globals.m_commonLvl.GetComponent<LevelScript>().m_2ndWaveObjInfo.m_oneTimeInstiate = false;
            Globals.m_commonLvl.GetComponent<LevelScript>().m_3rdWaveObjInfo.m_oneTimeInstiate = false;
            Globals.m_commonLvl.GetComponent<LevelScript>().m_4thWaveObjInfo.m_oneTimeInstiate = false;
            Globals.m_commonLvl.GetComponent<LevelScript>().m_5thWaveObjInfo.m_oneTimeInstiate = false;
            Globals.m_commonLvl.GetComponent<LevelScript>().m_5thWaveObjInfo.m_tempObjCnt = 0;
            Globals.m_commonLvl.GetComponent<LevelScript>().m_4thWaveObjInfo.m_tempObjCnt = 0;
            Globals.m_commonLvl.GetComponent<LevelScript>().m_3rdWaveObjInfo.m_tempObjCnt = 0;
            Globals.m_commonLvl.GetComponent<LevelScript>().m_2ndWaveObjInfo.m_tempObjCnt = 0;
            Globals.m_commonLvl.GetComponent<LevelScript>().m_1stWaveObjinfo.m_tempObjCnt = 0;

        }
    }
}
