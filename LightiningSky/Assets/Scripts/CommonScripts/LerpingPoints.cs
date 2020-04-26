using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpingPoints : MonoBehaviour
{
    public Transform[] m_targets;
    public int current;

    void Update()
    {
        if (transform.position != m_targets[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_targets[current].position, 25 * Time.smoothDeltaTime);
        }
        else
            current = (current + 1) % m_targets.Length;
    }
}



