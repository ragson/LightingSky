using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour
{


    //private float dist;
    //private bool dragging = false;
    //private Vector3 offset;
    //private Transform toDrag;
    private Vector3 touchPosition;
    private Rigidbody rb;
    private Vector3 direction;
    private float moveSpeed = 50;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        Vector3 v3;

        //if (Input.touchCount != 1)
        //{
        //    dragging = false;
        //    return;
        //}

        //Touch touch = Input.touches[0];
        //Vector3 pos = touch.position;

        //if (touch.phase == TouchPhase.Began)
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(pos);
        //    if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Draggable"))
        //    {
        //        Debug.Log("Here");
        //        toDrag = hit.transform;
        //        dist = hit.transform.position.z - Camera.main.transform.position.z;
        //        v3 = new Vector3(pos.x, pos.y, dist);
        //        v3 = Camera.main.ScreenToWorldPoint(v3);
        //        offset = toDrag.position - v3;
        //        dragging = true;
        //    }
        //}
        //if (dragging && touch.phase == TouchPhase.Moved)
        //{
        //    v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
        //    v3 = Camera.main.ScreenToWorldPoint(v3);
        //    toDrag.position = v3 + offset;
        //}
        //if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        //{
        //    dragging = false;
        //}
    }




    private float dist;
    private Vector3 v3Offset;
    private Plane plane;
    private bool ObjectMouseDown = false;
    public GameObject linkedObject;

    void OnMouseDown()
    {
        plane.SetNormalAndPosition(Camera.main.transform.forward, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        plane.Raycast(ray, out dist);
        v3Offset = transform.position - ray.GetPoint(dist);
        ObjectMouseDown = true;
    }

    void OnMouseDrag()
    {
        if (ObjectMouseDown == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dist;
            plane.Raycast(ray, out dist);
            Vector3 v3Pos = ray.GetPoint(dist);
            v3Pos.z = gameObject.transform.position.z;
            v3Offset.z = 0;
            transform.position = (v3Pos + v3Offset) ;

            if (linkedObject != null)
            {
                linkedObject.transform.position = (v3Pos + v3Offset);
            }
        }
    }

    void OnMouseOut()
    {
        ObjectMouseDown = false;
    }
}

