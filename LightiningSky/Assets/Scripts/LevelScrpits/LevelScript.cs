
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    public GameObjectInfo m_1stWaveObjinfo, m_2ndWaveObjInfo, m_3rdWaveObjInfo, m_4thWaveObjInfo,
                         m_5thWaveObjInfo;

    public IEnumerator MoveLerp(GameObjectInfo gameObjectInfo)
    {
        if (!gameObjectInfo.m_oneTimeInstiate)
        {
            gameObjectInfo.m_oneTimeInstiate = true;
            if (gameObjectInfo.m_tempObjCnt < gameObjectInfo.m_movingObjsCnt)
            {
                GameObject moveobject = Instantiate(gameObjectInfo.m_ObjectToMove, gameObjectInfo.m_poin0.position, Quaternion.Euler(gameObjectInfo.setAngle));

                if (gameObjectInfo.m_ObjectToMove != null)
                {
                    if (gameObjectInfo.m_ObjectToMove.name == "Enemy4")
                    {
                        Globals.enemy4List.Add(moveobject);
                    }
                }

                moveobject.transform.SetParent(gameObjectInfo.m_parent.transform);
                moveobject.AddComponent<LerpMovement>();
                moveobject.GetComponent<LerpMovement>().m_gameObjectInfo = gameObjectInfo;
                yield return new WaitForSeconds(3f);
                gameObjectInfo.m_oneTimeInstiate = false;
                gameObjectInfo.m_tempObjCnt++;
            }
        }
    }

    

    public void Start()
    {

        Globals.m_commonLvl = this.gameObject;
        objcnt = 0;
        Globals.enemy4List = new List<GameObject>();

        foreach (Transform tran in m_1stWaveObjinfo.m_parent.transform)
        {
            if (tran.name.Contains("Enemy1"))
            {
                Destroy(tran.gameObject);
            }
        }

        foreach (Transform tran in m_2ndWaveObjInfo.m_parent.transform)
        {
            if (tran.name.Contains("Enemy2"))
            {
                Destroy(tran.gameObject);
            }
        }

        foreach (Transform tran in m_2ndWaveObjInfo.m_parent.transform)
        {
            if (tran.name.Contains("Enemy3"))
            {
                Destroy(tran.gameObject);
            }
        }

        foreach (Transform tran in m_3rdWaveObjInfo.transform)
        {
            if (tran.name.Contains("Enemy4"))
            {
                Destroy(tran.gameObject);
            }
        }

        foreach (Transform tran in m_4thWaveObjInfo.m_parent.transform)
        {
            if (tran.name.Contains("Enemy4"))
            {
                Destroy(tran.gameObject);
            }
        }

        foreach (Transform tran in m_5thWaveObjInfo.m_parent.transform)
        {
            if (tran.name.Contains("BossEnemyHolder"))
            {
                Destroy(tran.gameObject);
            }
        }
    }
    
    public IEnumerator MoveQudaratic()
    {
        if (!m_1stWaveObjinfo.m_oneTimeInstiate)
        {
            m_1stWaveObjinfo.m_oneTimeInstiate = true;
            if (m_1stWaveObjinfo.m_tempObjCnt < m_1stWaveObjinfo.m_movingObjsCnt)
            {
                GameObject moveobject = Instantiate(m_1stWaveObjinfo.m_ObjectToMove, m_1stWaveObjinfo.m_poin0.position, Quaternion.Euler(m_1stWaveObjinfo.setAngle));
                moveobject.transform.SetParent(m_1stWaveObjinfo.m_parent.transform);
                moveobject.AddComponent<QuadraticBeizerCuveMovement>();
                moveobject.GetComponent<QuadraticBeizerCuveMovement>().m_gameObjectInfo = m_1stWaveObjinfo;
                yield return new WaitForSeconds(0.9f);
                m_1stWaveObjinfo.m_oneTimeInstiate = false;
                m_1stWaveObjinfo.m_tempObjCnt++;
            }
        }
    }
    public int objcnt = 0;
    public IEnumerator StatObjectRandomly()
    {
        if (objcnt < m_2ndWaveObjInfo.m_movingObjsCnt)
        {
            if (!m_2ndWaveObjInfo.m_oneTimeInstiate)
            {
                m_2ndWaveObjInfo.m_oneTimeInstiate = true;
                Transform mytransform = m_2ndWaveObjInfo.m_points[UnityEngine.Random.Range(0, m_2ndWaveObjInfo.m_points.Length)];
                GameObject selectedobj = m_2ndWaveObjInfo.m_movingObects[UnityEngine.Random.Range(0, m_2ndWaveObjInfo.m_movingObects.Length)];
                Vector3 angle = Vector3.zero;
                int speed = m_2ndWaveObjInfo.m_speeds[UnityEngine.Random.Range(0, m_2ndWaveObjInfo.m_speeds.Length)];
                if (selectedobj.name.Contains("Enemy2"))
                {
                    angle = new Vector3(0, 180, 0);

                }
                else
                    angle = new Vector3(90, 0, 0);

                GameObject moveobj = Instantiate(selectedobj, mytransform.position, Quaternion.Euler(angle));
                moveobj.transform.SetParent(m_2ndWaveObjInfo.transform);

                if (m_2ndWaveObjInfo.m_pathPoints.Length > 0)
                {
                    if (objcnt % 3 == 0)
                    {
                        moveobj.AddComponent<LerpingPoints>();
                        moveobj.GetComponent<LerpingPoints>().m_targets = m_2ndWaveObjInfo.m_pathPoints;

                    }
                    else
                    {
                        moveobj.AddComponent<MovingScript>();
                        moveobj.GetComponent<MovingScript>().speed = speed;
                    }
                }
                else
                {
                    moveobj.AddComponent<MovingScript>();
                    moveobj.GetComponent<MovingScript>().speed = speed;
                }





                //moveobj.AddComponent<MovingScript>();
                //moveobj.GetComponent<MovingScript>().speed = speed;
                yield return new WaitForSeconds(1f);
                m_2ndWaveObjInfo.m_oneTimeInstiate = false;
                objcnt++;
                if (objcnt == m_2ndWaveObjInfo.m_movingObjsCnt)
                {
                    m_2ndWaveObjInfo.m_oneTimeInstiate = true;
                }
            }
        }

    }

    public IEnumerator MoveObjectRandomly(GameObjectInfo gameObjectInfo)
    {
        if (!gameObjectInfo.m_oneTimeInstiate)
        {
            gameObjectInfo.m_oneTimeInstiate = true;
            if (gameObjectInfo.m_tempObjCnt < gameObjectInfo.m_movingObjsCnt)
            {
                GameObject moveobject = Instantiate(gameObjectInfo.m_ObjectToMove, gameObjectInfo.m_pathPoints[0].position, Quaternion.Euler(gameObjectInfo.setAngle));
                moveobject.transform.SetParent(gameObjectInfo.m_parent.transform);

                if (gameObjectInfo.m_ObjectToMove.name == "Enemy4")
                {
                    Globals.enemy4List.Add(moveobject);
                }

                moveobject.AddComponent<LerpingPoints>();
                moveobject.GetComponent<LerpingPoints>().m_targets = gameObjectInfo.m_pathPoints;
                yield return new WaitForSeconds(2f);
                gameObjectInfo.m_oneTimeInstiate = false;
                gameObjectInfo.m_tempObjCnt++;
            }
        }
    }
}

public interface ILevel
{
    //void Start();
    //void CurrentObject();
    IEnumerator MoveObject();
}
