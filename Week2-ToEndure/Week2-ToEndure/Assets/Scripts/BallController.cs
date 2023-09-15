using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //public float speed = 2f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        // if (Input.GetKey(KeyCode.A))
        // {
        //     Vector3 newPos = transform.position + Vector3.left * speed * Time.deltaTime;
        //     rb.MovePosition(newPos);
        // }else if (Input.GetKey(KeyCode.D))
        // {
        //     Vector3 newPos = transform.position + Vector3.right * speed * Time.deltaTime;
        //     rb.MovePosition(newPos);
        // }
        //
        // if (Input.GetKey(KeyCode.W))
        // {
        //     Vector3 newPos = transform.position + Vector3.forward * speed * Time.deltaTime;
        //     rb.MovePosition(newPos);
        // }else if(Input.GetKey(KeyCode.S))
        // {
        //     Vector3 newPos = transform.position + Vector3.back * speed * Time.deltaTime;
        //     rb.MovePosition(newPos);
        // }

        if (Input.GetKey(KeyCode.S))
        {
            rb.useGravity = true;
        }
        
    }
}
