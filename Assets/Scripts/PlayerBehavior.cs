using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehavior : MonoBehaviour
{
    //public Vector3 turnAngle = new Vector3(0,100f,0);
    public float turnSpeed = 2f;
    public float runtime = 0.1f;
    
    private Rigidbody rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public void RotateTheView(int dir)
    {
        
        //this.transform.Rotate(Vector3.up * dir * turnSpeed * Time.deltaTime);
        //Debug.Log("Rotata!");
        //rb.DORotate(Vector3.up * dir * turnSpeed * Time.deltaTime, reactSpeed);
        // Quaternion deltaRotation = Quaternion.Euler(turnAngle * Time.deltaTime * dir);
        // rb.MoveRotation(rb.rotation * deltaRotation);

        //Vector3 newRotate = transform.rotation.eulerAngles + turnAngle * Time.deltaTime * dir;
        transform.Rotate(0,turnSpeed * dir,0);
        
    }

    public void CharacterMoving(float force)
    {
        Debug.Log("move");
        //rb.velocity = transform.forward;


        Vector3 endPos = transform.position + transform.forward * force;
        transform.DOMove(endPos, runtime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("stop moving");
    }

    void StopMoving()
    {
        //rb.velocity = Vector3.zero;
        Debug.Log("stop moving");
    }
}
