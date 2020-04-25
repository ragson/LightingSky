using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class GameObjectInfo : MonoBehaviour
{


    public Transform[] m_points;
    public Transform[] m_pathPoints;
    public GameObject[] m_movingObects;
    public int[] m_speeds;
    public bool m_applyOperator;
    public Transform m_poin0;
    public Transform m_point1;
    public Transform m_point2;
    public GameObject m_ObjectToMove;
    public GameObject m_parent;
    public Vector3 setAngle;
    public float m_objectSpeed;
    public int m_movingObjsCnt;
    [HideInInspector]
    public int m_tempObjCnt;
    [HideInInspector]
    public bool m_oneTimeInstiate;
    [HideInInspector]
    public GameObject m_tempobjecttomove;


}
