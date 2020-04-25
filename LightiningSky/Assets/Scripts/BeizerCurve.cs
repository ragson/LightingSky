using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeizerCurve : MonoBehaviour
{


    //public LineRenderer m_linrender;
    public int numberofpoints = 50;
    public Transform m_poin0;
    public Transform m_point1;
    public Transform m_point2;
    public Vector3[] m_noofPosCovered = new Vector3[50];
    // Start is called before the first frame update
    void Start()
    {
        //m_linrender.positionCount = numberofpoints;
        //DrawLinearCurve();
        DrawQuadraticBeizerCurve();
    }

    private void Update()
    {
       
    }

    void DrawLinearCurve()
    {

        for (int i = 0; i < numberofpoints; i++)
        {
            float t = i / (float)numberofpoints;

            m_noofPosCovered[i] = CalulateLinearBeizerCurve(t, m_poin0.position, m_point1.position);
        }
        //m_linrender.SetPositions(m_noofPosCovered);
    }


    void DrawQuadraticBeizerCurve()
    {

        for (int i = 0; i < numberofpoints; i++)
        {
            float t = i / (float)numberofpoints;

            m_noofPosCovered[i] = CalculateQuadraticBeizerCurve(t, m_poin0.position, m_point1.position, m_point2.position);
        }
        //m_linrender.SetPositions(m_noofPosCovered);
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

    Vector3 CalulateLinearBeizerCurve(float t, Vector3 point0, Vector3 point1)
    {
        //P0 + t(P1 – P0)
        return point0 + t * (point1 - point0);
    }

}
