using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticBeizerCuveMovement : MonoBehaviour
{
    [HideInInspector]
    public GameObjectInfo m_gameObjectInfo;

    float speed = 9;
    bool onetime;
    float m_time;
    int m_tempObjectCnt;

    public void MoveObject()
    {
        if (m_time < 1)
        {
            m_time += (Time.smoothDeltaTime / speed);

            transform.position = CalculateQuadraticBeizerCurve(m_time, m_gameObjectInfo.m_poin0.position, m_gameObjectInfo.m_point1.position, m_gameObjectInfo.m_point2.position);
            if(m_gameObjectInfo.m_applyOperator)
            transform.rotation = Quaternion.Euler(90 - (speed * (m_time * speed)), 90, 90);
            else
                transform.rotation = Quaternion.Euler(90 + (speed * (m_time * speed)), 90, 90);
        }

        //if (Vector3.Distance(transform.position, m_gameObjectInfo.m_point2.position) < 1)
        //{
        //    Globals.EnemyDestroyCnt++;
        //    Debug.Log(Globals.EnemyDestroyCnt);
        //    Destroy(transform.gameObject);
        //}
    }

    private void FixedUpdate()
    {
       MoveObject();
    }

    Vector3 CalculateQuadraticBeizerCurve(float t, Vector3 point0, Vector3 point1, Vector3 point2)
    {
        //(1-t)2P0 + 2(1-t)tP1 + t2P2

        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * point0;
        p += 2 * u * t * point1;
        p += tt * point2;

        return p;
    }
}
