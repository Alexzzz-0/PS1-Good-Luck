using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComplexGameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private TextMeshProUGUI endInsturction;
    [SerializeField] private GameObject pinkMan;
    [SerializeField] private ParticleSystem explode;
    [SerializeField] private AudioSource zizi;
    [SerializeField] private AudioSource scream;

    public float force = 1f;

    private List<Transform> ballTrans = new List<Transform>();
    private List<Animator> PinkMenAni = new List<Animator>();
    private GameObject man;
    private GameObject ballFather;
    private GameObject menFather;
    private Rigidbody manRb;
    private float time = 20f;
    private float startRunCountDown = 2.5f;
    private float endCount = 10f;
   
    private int round = 0;
    private int spawnCount = 0;
    private bool startRunCount = false;
    
    
    private void Start()
    {
        man = GameObject.FindGameObjectWithTag("Player");

        manRb = man.transform.GetChild(0).GetComponent<Rigidbody>();
        Invoke("ConstrainMan",1f);

        ballFather = new GameObject("BallFather");
        menFather = new GameObject("MenFather");
        
        round = 1;
        
        Invoke("EndInsturctionGone",3f);
    }

    void EndInsturctionGone()
    {
        endInsturction.text = null;
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }
        

        #region Spawn Balls

        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject upBall = Instantiate(ball);
            upBall.transform.parent = ballFather.transform;
            // upBall.name = spawnCount.ToString();
            // spawnCount += 1;
            ballTrans.Add(upBall.transform);
            upBall.transform.position = new Vector3(0, 8, 0);
            upBall.GetComponent<Rigidbody>().AddForce(Vector3.down * force);
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject leftBall = Instantiate(ball);
            leftBall.transform.parent = ballFather.transform;
            // leftBall.name = spawnCount.ToString();
            // spawnCount += 1;
            ballTrans.Add(leftBall.transform);
            leftBall.transform.position = new Vector3(-5, 0, 0);
            leftBall.GetComponent<Rigidbody>().AddForce(Vector3.right * force);
            
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject frontBall = Instantiate(ball);
            frontBall.transform.parent = ballFather.transform;
            // frontBall.name = spawnCount.ToString();
            // spawnCount += 1;
            ballTrans.Add(frontBall.transform);
            frontBall.transform.position = new Vector3(0, 0, 0);
            
            //frontBall.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject rightBall = Instantiate(ball);
            rightBall.transform.parent = ballFather.transform;
            // rightBall.name = spawnCount.ToString();
            // spawnCount += 1;
            ballTrans.Add(rightBall.transform);
            rightBall.transform.position = new Vector3(5, 0, 0);
            rightBall.GetComponent<Rigidbody>().AddForce(Vector3.left * force);
            
        }

        #endregion

        time -= Time.deltaTime;
        if (time <= 0)
        {
            
            time = 20f;
            int childNum = ballTrans.Count;
            if (childNum >= 3)
            {
                Debug.Log("spawn human");
                for (int i = 0; i < 3; i++)
                {
                    //randomly choose a ball
                    Transform pinkBall = ballTrans[Random.Range(0, ballTrans.Count)];
                    
                    //prepare the explode to the right position
                    explode.transform.position = pinkBall.position;
                    
                    //spawn a pink man
                    GameObject newPinkMan = Instantiate(pinkMan);
                    newPinkMan.transform.position = pinkBall.position;
                    newPinkMan.transform.parent = menFather.transform;
                    
                    //add pink men's animator to the list
                    PinkMenAni.Add(newPinkMan.GetComponent<Animator>()); 
                    
                    //play the fx
                    explode.Play();
                    
                    //destroy game object and remove transform from the list
                    Destroy(pinkBall.gameObject);
                    ballTrans.Remove(pinkBall);
                }
                
                //start count down
                startRunCount = true;
                
                //count how many times human are spawned
                round += 1;
                
                zizi.Play();
                scream.Play();
            }
           
        }

       
        

        if (startRunCount)
        {
            startRunCountDown -= Time.deltaTime;
        }

        if (startRunCountDown <= 0)
        {
            //get all the animator controller and set them to run state
            SetMenToRun();
            
            Debug.Log("StartRuning");
            startRunCount = false;
            startRunCountDown = 2.5f;
        }
        
        if (round >= 4)
        {
            endCount -= Time.deltaTime;
        }

        if (endCount <= 0)
        {
            SceneManager.LoadScene(2);
        }
        
    }

    void SetMenToRun()
    {
        int pinkMen = PinkMenAni.Count;
        for (int j = 0; j < pinkMen; j++)
        {
            if (PinkMenAni[0] != null)
            {
                PinkMenAni[0].SetBool("run",true);
                //Destroy(PinkMenAni[0].gameObject);
                PinkMenAni.RemoveAt(0);
            }
        }
    }
    
    void ConstrainMan()
    {
        //Debug.Log("Constrain");
        manRb.constraints = RigidbodyConstraints.FreezePosition;
    }

    void AddText()
    {
        
    }
}
