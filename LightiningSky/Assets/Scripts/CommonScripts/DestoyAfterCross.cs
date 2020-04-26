using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyAfterCross : MonoBehaviour
{

    GameObject m_destroyPoint1, m_destroyPoint2,m_destroyPoint3;
    
    private void Awake()
    {
        m_destroyPoint1 = GameObject.Find("DestroyPoint1");
        m_destroyPoint2= GameObject.Find("DestoyPoint2");
        m_destroyPoint3 = GameObject.Find("DestoyPoint3");
    }

    private void Update()
    {
        if (m_destroyPoint1 != null && m_destroyPoint2 != null&&m_destroyPoint3!=null)
        {
            if (transform.position.x < m_destroyPoint1.transform.position.x || transform.position.y < m_destroyPoint2.transform.position.y||
                transform.position.x > m_destroyPoint3.transform.position.x)
                Destroy(transform.gameObject);
        }
    }
}
