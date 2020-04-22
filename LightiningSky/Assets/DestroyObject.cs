using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour, IDestoy
{
    [HideInInspector]
    public float m_timeAfterDestroy;

    void Update()
    {
        DestroyMe();
    }

    public void DestroyMe()
    {
       
        Destroy(this.gameObject,m_timeAfterDestroy);
    }
}

interface IDestoy
{
    void DestroyMe();
}