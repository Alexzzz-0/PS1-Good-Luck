using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject man;
    [SerializeField] private TextMeshProUGUI indication;

    public float force = 1f;

    private GameObject ballFather;
    private Rigidbody manRb;
    private float scale = 0;
    private float time = 20f;
    private int round = 0;
    
    
    private void Start()
    {
        manRb = man.GetComponent<Rigidbody>();
        Invoke("ConstrainMan",1f);

        ballFather = new GameObject("BallFather");

        round = 1;

        indication.text = null;
    }

    
    private void Update()
    {
        #region LoadScene

        if (Input.GetKeyDown(KeyCode.R))
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }

        #endregion

        #region QuitApp

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        #endregion
        
        // //destroy all balls
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Destroy(ballFather);
        // }

        if (Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene(1);
        }

        #region control the size of balls

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (round <= 3)
            {
                round += 1;
            }
            else
            {
                indication.text = "It has been the biggest.";
                Invoke("DeleteText",1f);
            }
            
        }else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (round >= 1)
            {
                round -= 1;
            }
            else
            {
                indication.text = "It has been the smallest.";
                Invoke("DeleteText",1f);
            }
            
        }
        
        
        switch (round)
        {
            case 0:
                scale = 0.2f;
                
                break;
            case 1:
                scale = 0.5f;
                indication.text = null;
                break;
            case 2:
                scale = 1f;
                indication.text = null;
                break;
            case 3:
                scale = 5f;
                indication.text = null;
                break;
            case 4:
                scale = 10f;
                
                break;
        }
            
        #endregion

        #region Spawn Balls

        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject upBall = Instantiate(ball);
            upBall.transform.parent = ballFather.transform;
            upBall.transform.localScale = new Vector3(scale, scale, scale);
            upBall.transform.position = new Vector3(0, 8, 0);
            upBall.GetComponent<Rigidbody>().AddForce(Vector3.down * force);
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject leftBall = Instantiate(ball);
            leftBall.transform.parent = ballFather.transform;
            leftBall.transform.localScale = new Vector3(scale, scale, scale);
            leftBall.transform.position = new Vector3(-5, 0, 0);
            leftBall.GetComponent<Rigidbody>().AddForce(Vector3.right * force);
            
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject frontBall = Instantiate(ball);
            frontBall.transform.parent = ballFather.transform;
            frontBall.transform.localScale = new Vector3(scale, scale, scale);
            frontBall.transform.position = new Vector3(0, 0, 0);
            
            //frontBall.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject rightBall = Instantiate(ball);
            rightBall.transform.parent = ballFather.transform;
            rightBall.transform.localScale = new Vector3(scale, scale, scale);
            rightBall.transform.position = new Vector3(5, 0, 0);
            rightBall.GetComponent<Rigidbody>().AddForce(Vector3.left * force);
            
        }

        #endregion

        
    }

    void ConstrainMan()
    {
        //Debug.Log("Constrain");
        manRb.constraints = RigidbodyConstraints.FreezePosition;
    }

    void DeleteText()
    {
        indication.text = null;
    }
}
