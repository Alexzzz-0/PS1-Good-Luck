using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehavior : MonoBehaviour
{
    public Vector3 turnAngle = new Vector3(0,100f,0);
    public float speedLoss = 0.1f;
    
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
        Quaternion deltaRotation = Quaternion.Euler(turnAngle * Time.deltaTime * dir);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public void CharacterMoving(float force)
    {
        Debug.Log("move");
        rb.AddForce( transform.forward * force);
        
    }
}
