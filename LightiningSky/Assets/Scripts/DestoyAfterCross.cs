using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyAfterCross : MonoBehaviour
{

    GameObject m_destroyPoint1, m_destroyPoint2;
    
    private void Awake()
    {
        m_destroyPoint1 = GameObject.Find("DestroyPoint1");
        m_destroyPoint2= GameObject.Find("DestoyPoint2");
       
    }

    private void Update()
    {
        if (m_destroyPoint1 != null && m_destroyPoint2 != null)
        {
            if (transform.position.x < m_destroyPoint1.transform.position.x || transform.position.y < m_destroyPoint2.transform.position.y)
                Destroy(transform.gameObject);
        }
    }
}
