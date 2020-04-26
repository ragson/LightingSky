using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWave : MonoBehaviour
{
    private Vector3 _startPosition;
    public float speedUpDown = 1;
    public float distanceUpDown = 1;
    void Start()
    {
        //_startPosition = transform.position;
    }


    void Update()
    {
       transform.position = _startPosition + new Vector3(Mathf.Sin(Time.time)*5, transform.position.y, transform.position.z);
        
    }
}
