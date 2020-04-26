using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public int speed;
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime*speed, Camera.main.transform);
    }
}
