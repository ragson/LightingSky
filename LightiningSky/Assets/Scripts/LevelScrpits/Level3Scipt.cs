using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Scipt : MonoBehaviour,ILevel
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
                moveobject.transform.SetParent(gameObjectInfo.m_parent.transform);
                moveobject.AddComponent<LerpMovement>();
                moveobject.GetComponent<LerpMovement>().m_gameObjectInfo = gameObjectInfo;
                yield return new WaitForSeconds(3f);
                gameObjectInfo.m_oneTimeInstiate = false;
                gameObjectInfo.m_tempObjCnt++;
            }
        }
    }

    private void Update()
    {
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveQudaratic()
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
    int objcnt = 0;
    public IEnumerator StarrtObjectRandomly()
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

    IEnumerator MoveObjectRandomly(GameObjectInfo gameObjectInfo)
    {
        if (!gameObjectInfo.m_oneTimeInstiate)
        {
            gameObjectInfo.m_oneTimeInstiate = true;
            if (gameObjectInfo.m_tempObjCnt < gameObjectInfo.m_movingObjsCnt)
            {
                GameObject moveobject = Instantiate(gameObjectInfo.m_ObjectToMove, gameObjectInfo.m_pathPoints[0].position, Quaternion.Euler(gameObjectInfo.setAngle));
                moveobject.transform.SetParent(gameObjectInfo.m_parent.transform);
                moveobject.AddComponent<LerpingPoints>();
                moveobject.GetComponent<LerpingPoints>().m_targets = gameObjectInfo.m_pathPoints;
                yield return new WaitForSeconds(2f);
                gameObjectInfo.m_oneTimeInstiate = false;
                gameObjectInfo.m_tempObjCnt++;
            }
        }
    }

    public IEnumerator MoveObject()
    {
        StartCoroutine(MoveQudaratic());
        yield return new WaitUntil(() => m_1stWaveObjinfo.m_tempObjCnt == 6);
        StartCoroutine(StarrtObjectRandomly());
        yield return new WaitUntil(() => objcnt == m_2ndWaveObjInfo.m_movingObjsCnt);
        StartCoroutine(MoveObjectRandomly(m_3rdWaveObjInfo));
        StartCoroutine(MoveObjectRandomly(m_4thWaveObjInfo));
        yield return new WaitUntil(() => Globals.Enemy4DstrCnt == 2);
        StartCoroutine(MoveLerp(m_5thWaveObjInfo));
    }
}
