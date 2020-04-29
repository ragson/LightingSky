using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelScript : MonoBehaviour
{
   public ILevel level;
   
    //public GameObject m_gameView;
    //public GameObject[] m_levelsObjArr;
    //public GameObject m_levelScreenPage;
    private void Start()
    {
       
    }


    public void Selectlevel(int lvlno)
    {

       
        LevelObjects levelObjects = GameObject.Find("AllLevelObjects").GetComponent<LevelObjects>();
        levelObjects.m_player.SetActive(true);
        levelObjects.m_levelScreenPage.SetActive(false);
        if (!levelObjects.m_gameView.activeSelf)
            levelObjects.m_gameView.SetActive(true);

        level = null;
        GameObject.Find("GameView").transform.position = new Vector3(0, 0, 0);
        
        switch (lvlno)
        {

            case 1:
                levelObjects.m_levelsObjArr[0].SetActive(true);
                level = levelObjects.m_levelsObjArr[0].GetComponent<Level1Script>();
               
                break;
            case 2:
                levelObjects.m_levelsObjArr[1].SetActive(true);
                level = levelObjects.m_levelsObjArr[1].GetComponent<Level2Script>();
             

                break;
            case 3:
                levelObjects.m_levelsObjArr[2].SetActive(true);
                level = levelObjects.m_levelsObjArr[2].GetComponent<Level3Scipt>();
               

                break;
            case 4:
                levelObjects.m_levelsObjArr[3].SetActive(true);
                level = levelObjects.m_levelsObjArr[3].GetComponent<Level4Script>();
                
                break;
            case 5:
                levelObjects.m_levelsObjArr[4].SetActive(true);
                level = levelObjects.m_levelsObjArr[4].GetComponent<Level5Script>();
              
                break;
                
        }
        Globals.m_currentLvl = level;

        // level.Start();
        //  GameObject.Find("LevelController").GetComponent<SelectLevelScript>().enabled = true;
    }

    private void Update()
    {
        if (level != null)
            StartCoroutine(level.MoveObject());
    }

}
