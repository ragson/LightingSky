using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public Rigidbody rigidBody;
    public float angleChangingSpeed;
    public float movementSpeed;
    void FixedUpdate()
    {
        Vector3 direction = (Vector3)target.position - (Vector3)this.transform.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rigidBody.angularVelocity =transform.forward*-angleChangingSpeed * rotateAmount;
        rigidBody.velocity = transform.up * movementSpeed;
    }


    //Reference Script

    /*public Transform target;
    public Rigidbody2D rigidBody;
    public float angleChangingSpeed;
    public float movementSpeed;
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rigidBody.angularVelocity = -angleChangingSpeed * rotateAmount;
        rigidBody.velocity = transform.up * movementSpeed;
    }
    */
}
