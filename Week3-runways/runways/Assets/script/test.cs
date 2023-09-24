using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    public float speed = 10f;
    //public KeyCode key;

    public float upForce = 1000f;
    public float forwardForce = 300f;
    
    private Rigidbody rb;

    [SerializeField] private TextMeshProUGUI retryTimes;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Retry();
        }
        
        if (Input.GetKey(KeyCode.A))
        {


            rb.MovePosition(transform.position + Vector3.left * Time.deltaTime * forwardForce);

        }
        
        if (Input.GetKey(KeyCode.D))
        {


            rb.MovePosition(transform.position + Vector3.right * Time.deltaTime * speed);

        }
        
        if (Input.GetKey(KeyCode.W))
        {


            rb.MovePosition(transform.position + Vector3.up * Time.deltaTime * upForce);

        }
        
        if (Input.GetKey(KeyCode.S))
        {


            rb.MovePosition(transform.position + Vector3.down * Time.deltaTime * speed);
        }

        if (transform.position.y <= -5f)
        {
            Retry();
        }

        // if (Input.GetKeyDown(key))
        // {
        //     rb.DOJump(transform.position + Vector3.left * Time.deltaTime * speed, 10f, 1, 1f);
        // }
    }

    void Retry()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
