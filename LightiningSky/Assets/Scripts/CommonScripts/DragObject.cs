using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 touchPosition;
    private Rigidbody rb;
    private Vector3 direction;
    private float moveSpeed = 50;


    private void Start()
    {
    }
    Vector3 curPosition;
    void Update()
    {
        Vector3 v3;



        //if (curPosition.x > -20 || curPosition.x < 20 || curPosition.y > -40)
        //{


            if (Input.GetMouseButton(0)) // 0 for left and 1 for right click
            {
                curPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector2(curPosition.x, transform.position.y);
            }

            if (Input.GetMouseButtonUp(0)) // 0 for left and 1 for right click
            {

                transform.position = new Vector2(curPosition.x, transform.position.y);
            }


    //    }
    }

}

