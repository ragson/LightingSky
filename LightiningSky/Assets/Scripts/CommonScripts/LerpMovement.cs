using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    [HideInInspector]
   public GameObjectInfo m_gameObjectInfo;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(m_gameObjectInfo.m_poin0.position, m_gameObjectInfo.m_point1.position);
    }

    void MakelerpMOvement()
    {
        float distCovered = (Time.time - startTime) * m_gameObjectInfo.m_objectSpeed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(m_gameObjectInfo.m_poin0.position, m_gameObjectInfo.m_point1.position, fractionOfJourney);

        //if (Vector3.Distance(transform.position, m_gameObjectInfo.m_point1.position) < 1)
        //{
        //    Globals.EnemyDestroyCnt++;
            
        //    Destroy(transform.gameObject);
        //}
    }

    // Move to the target end position.
    void Update()
    {
        MakelerpMOvement();
        
    }
}
