using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    public KeyCode key;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
        {
            rb.MovePosition(transform.position + Vector3.right * Time.deltaTime * speed );
        }
    }
}
