using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearbeizerCurveMovement : MonoBehaviour
{
     Vector3[] m_noofPosCovered = new Vector3[50];
    public Transform m_poin0;
    public Transform m_point1;
    public GameObject m_ObjectToMove;
    public GameObject m_parent;
    public float speed;
    public Vector3 setAngle;
    bool onetime;
    GameObject objecttomove;
    float m_time = 0;

    // Start is called before the first frame update
    void Start()
    {
        // DrawLinearCurve();
    }

    private void Update()
    {
        DrawLinearCurve();
    }

    void DrawLinearCurve()
    {
        // refernce for linear bezier curve;
        //for (int i = 0; i < numberofpoints; i++)
        //{
        //    float t = i / (float)numberofpoints;

        //    m_noofPosCovered[i] = CalulateLinearBeizerCurve(t, m_poin0.position, m_point1.position);
        //}

        if (!onetime)
        {
            onetime = true;
            objecttomove = Instantiate(m_ObjectToMove, m_noofPosCovered[0], Quaternion.Euler(setAngle));
            objecttomove.transform.SetParent(m_parent.transform);
        }

        if (m_time < 1)
        {
            m_time += (Time.smoothDeltaTime / speed);
            objecttomove.transform.position= CalulateLinearBeizerCurve(m_time, m_poin0.position, m_point1.position);
        }
    }

    Vector3 CalulateLinearBeizerCurve(float t, Vector3 point0, Vector3 point1)
    {
        //P0 + t(P1 – P0)
        return point0 + t * (point1 - point0);
    }
}
