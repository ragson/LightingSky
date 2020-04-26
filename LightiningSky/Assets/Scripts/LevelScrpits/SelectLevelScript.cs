using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelScript : MonoBehaviour
{
    ILevel level;
   // public GameObject m_lvl1Obj, m_lvl2Obj, m_lvl3Obj, m_lvl4Obj, m_lvl5Obj;
    public GameObject m_gameView;
    public GameObject[] m_levelsObjArr;
    public GameObject m_levelScreenPage;

    public void Selectlevel(int lvlno)
    {
        m_levelScreenPage.SetActive(false);
        if (!m_gameView.activeSelf)
            m_gameView.SetActive(true);

       
        GameObject.Find("GameView").transform.position = new Vector3(0, 0, 0);
        GameObject.Find("LevelController").GetComponent<SelectLevelScript>().enabled = true;
        switch (lvlno)
        {

            case 1:
                m_levelsObjArr[0].SetActive(true);
                level = m_levelsObjArr[0].GetComponent<Level1Script>();
                m_levelsObjArr[0].GetComponent<Level1Script>().StopAllCoroutines();
                m_levelsObjArr[0].GetComponent<Level1Script>().Start();
                
                break;
            case 2:
                m_levelsObjArr[1].SetActive(true);
                level = m_levelsObjArr[1].GetComponent<Level2Script>();
                m_levelsObjArr[1].GetComponent<Level2Script>().StopAllCoroutines();
                m_levelsObjArr[1].GetComponent<Level2Script>().Start();
              
                break;
            case 3:
                m_levelsObjArr[2].SetActive(true);
                level = m_levelsObjArr[2].GetComponent<Level3Scipt>();
                m_levelsObjArr[2].GetComponent<Level3Scipt>().StopAllCoroutines();
                m_levelsObjArr[2].GetComponent<Level3Scipt>().Start();
               
                break;
            case 4:
                m_levelsObjArr[3].SetActive(true);
                level = m_levelsObjArr[3].GetComponent<Level4Script>();
                m_levelsObjArr[3].GetComponent<Level4Script>().StopAllCoroutines();
                m_levelsObjArr[3].GetComponent<Level4Script>().Start();
                break;
            case 5:
                m_levelsObjArr[4].SetActive(true);
                level = m_levelsObjArr[4].GetComponent<Level5Script>();
                m_levelsObjArr[4].GetComponent<Level5Script>().StopAllCoroutines();
                m_levelsObjArr[4].GetComponent<Level5Script>().Start();
                break;
        }
    }

    private void Update()
    {
        if (level != null)
            StartCoroutine(level.MoveObject());
    }

}
