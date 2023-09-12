using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehavior : MonoBehaviour
{
    //public Vector3 turnAngle = new Vector3(0,100f,0);
    //[SerializeField] private TextMeshPro objectVelocity;

    public KeyCode left;
    public KeyCode right;
    
    public float turnSpeed = 2f;
    public float runtime = 0.1f;

    public float quickTurnSpeed = 2f;
    public float slowTurnSpeed = 2f;
    public float moveSpeed = 10f;
    public float velocity;

    private void Start()
    {
        //rb = this.GetComponent<Rigidbody>();
    }

    enum ObjectState
    {
        rotate,
        move
    }

    private ObjectState _objectState = ObjectState.rotate;
    
    public void Update()
    {
        //objectVelocity.text = velocity.ToString();

        switch (_objectState)
        {
            case ObjectState.rotate:
                if (Input.GetKey(left))
                {
                    transform.Rotate(0,quickTurnSpeed * (-1),0);
                }else if (Input.GetKey(right))
                {
                    transform.Rotate(0,quickTurnSpeed,0);
                }
                
                if (Input.GetKeyUp(left) || Input.GetKeyUp(right))
                {
                    _objectState = ObjectState.move;
                }
                break;
            case ObjectState.move:

                // if (velocity >= 0)
                // {
                //     velocity -= Time.deltaTime;
                //     
                //     
                //    
                //
                //     // if (Input.GetKey(left))
                //     // {
                //     //     transform.Rotate(0,slowTurnSpeed * Time.deltaTime * (-1),0);
                //     // }else if (Input.GetKey(right))
                //     // {
                //     //     transform.Rotate(0,slowTurnSpeed * Time.deltaTime,0);
                //     // }
                // }
                
                Vector3 newPos = transform.position + transform.forward * moveSpeed * Time.deltaTime;
                transform.position = newPos;
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("crush");
            _objectState = ObjectState.rotate;
            velocity = (other.gameObject.GetComponent<PlayerBehavior>().velocity + velocity) / 2;
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall");
            _objectState = ObjectState.rotate;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("done");
            Destroy(gameObject);
        }
    }
    
    
    
    // public void RotateTheView(int dir)
    // {
    //     
    //     //this.transform.Rotate(Vector3.up * dir * turnSpeed * Time.deltaTime);
    //     //Debug.Log("Rotata!");
    //     //rb.DORotate(Vector3.up * dir * turnSpeed * Time.deltaTime, reactSpeed);
    //     // Quaternion deltaRotation = Quaternion.Euler(turnAngle * Time.deltaTime * dir);
    //     // rb.MoveRotation(rb.rotation * deltaRotation);
    //
    //     //Vector3 newRotate = transform.rotation.eulerAngles + turnAngle * Time.deltaTime * dir;
    //     transform.Rotate(0,turnSpeed * dir,0);
    //     
    // }
    //
    // public void CharacterMoving(float force)
    // {
    //     Debug.Log("move");
    //     //rb.velocity = transform.forward;
    //
    //
    //     Vector3 endPos = transform.position + transform.forward * force;
    //     transform.DOMove(endPos, runtime);
    // }
    //
    // private void OnCollisionEnter(Collision other)
    // {
    //     Debug.Log("stop moving");
    // }
    //
    // void StopMoving()
    // {
    //     //rb.velocity = Vector3.zero;
    //     Debug.Log("stop moving");
    // }
}
