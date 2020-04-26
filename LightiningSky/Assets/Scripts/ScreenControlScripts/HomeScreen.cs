using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    public Text m_homeScreenTxt;
    public GameObject m_levelScreenPage;
    public GameObject m_homePage;
    public GameObject m_player;

    private void OnEnable()
    {
        //Set player saved score on home page 
        if (PlayerPrefs.GetInt("Score") != 0)
        {
            m_homeScreenTxt.text = "Score " + PlayerPrefs.GetInt("Score").ToString();
        }
    }

    //switch from home page to level screen
    public void OpenLevelScreen()
    {
        m_homePage.SetActive(false);
        m_levelScreenPage.SetActive(true);       
    }
}
