using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject humanA;
    [SerializeField] private GameObject humanB;
    [SerializeField] private GameObject humanC;
    [SerializeField] private GameObject humanD;

    public KeyCode playerAleft;
    public KeyCode playerAright;

    public KeyCode playerBleft;
    public KeyCode playerBright;

    public KeyCode playerCleft;
    public KeyCode playerCright;

    public KeyCode playerDleft;
    public KeyCode playerDright;

    public TextMeshProUGUI gameStateText;

    public float distance = 1f;
    
    private float checkTime = 100f;
    
    private bool canMove = true;
    private bool Arotate = false;
    private bool Brotate = false;
    private bool Crotate = false;
    private bool Drotate = false;

    enum GameState
    {
        Start,
        check,
        hold,
        rotate,
        run
    }

    private GameState _gameState = GameState.Start;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }

        switch (_gameState)
        {
            case GameState.Start:
                gameStateText.text = "Start!";
                CRotate();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _gameState = GameState.run;
                }
                break;
            case GameState.check:
                gameStateText.text = "Check!";
                Invoke("check",1f);
                if (Arotate || Brotate || Crotate || Drotate)
                {
                    _gameState = GameState.rotate;
                }
                else
                {
                    _gameState = GameState.hold;
                }
                break;
            case GameState.hold:
                gameStateText.text = "Hold!";
                
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _gameState = GameState.run;
                }
                break;
            case GameState.run:
                gameStateText.text = "Move!";
                Move();
                _gameState = GameState.check;
                break;
            case GameState.rotate:
                gameStateText.text = "Rotate!";
                if (Arotate)
                {
                    ARotate();
                }

                if (Brotate)
                {
                    BRotate();
                }
                
                if (Crotate)
                {
                    CRotate();
                }
                
                if (Drotate)
                {
                    DRotate();
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Move();
                }
                break;
        }
        
        //checkTime -= Time.deltaTime;
        //Debug.Log(checkTime.ToString());

        // if (Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     //canMove = false;
        //     humanA.GetComponent<PlayerBehavior>().CharacterMoving(5f);
        //     humanB.GetComponent<PlayerBehavior>().CharacterMoving(5f);
        //     humanC.GetComponent<PlayerBehavior>().CharacterMoving(1.5f);
        //     humanD.GetComponent<PlayerBehavior>().CharacterMoving(2f);
        //     checkTime = 3f;
        // }
    }

    void ARotate()
    {
        if (Input.GetKey(playerAleft))
        {
            humanA.GetComponent<PlayerBehavior>().RotateTheView(-1);
        }else if (Input.GetKey(playerAright))
        {
            humanA.GetComponent<PlayerBehavior>().RotateTheView(1);
        }
    }

    void BRotate()
    {
        if (Input.GetKey(playerBleft))
        {
            humanB.GetComponent<PlayerBehavior>().RotateTheView(-1);
        }else if (Input.GetKey(playerBright))
        {
            humanB.GetComponent<PlayerBehavior>().RotateTheView(1);
        }
    }

    void CRotate()
    {
        if (Input.GetKey(playerCleft))
        {
            humanC.GetComponent<PlayerBehavior>().RotateTheView(-1);
        }else if (Input.GetKey(playerCright))
        {
            humanC.GetComponent<PlayerBehavior>().RotateTheView(1);
        }
    }

    void DRotate()
    {
        if (Input.GetKey(playerDleft))
        {
            humanD.GetComponent<PlayerBehavior>().RotateTheView(-1);
        }else if (Input.GetKey(playerDright))
        {
            humanD.GetComponent<PlayerBehavior>().RotateTheView(1);
        }
    }

    void check()
    {
        float AB = Vector3.Distance(humanA.transform.position, humanB.transform.position);
        float AC = Vector3.Distance(humanA.transform.position, humanB.transform.position);
        float AD = Vector3.Distance(humanA.transform.position, humanB.transform.position);
        float BC = Vector3.Distance(humanB.transform.position, humanC.transform.position);
        float BD = Vector3.Distance(humanB.transform.position, humanD.transform.position);
        float CD = Vector3.Distance(humanC.transform.position, humanD.transform.position);

        if (AB <= distance)
        {
            Debug.Log("AB");
            Arotate = true;
            Brotate = true;
        }
        
        if (AC <= distance)
        {
            Arotate = true;
            Crotate = true;
        }
        
        if (AD <= distance)
        {
            Arotate = true;
            Drotate = true;
        }
        
        if (BC <= distance)
        {
            Crotate = true;
            Brotate = true;
        }
        
        if (BD <= distance)
        {
            Drotate = true;
            Brotate = true;
        }
        
        if (CD <= distance)
        {
            Crotate = true;
            Drotate = true;
        }

        //Debug.Log(AB.ToString()+"\n"+AC.ToString()+"\n"+AD.ToString()+"\n"+BC.ToString()+"\n"+BD.ToString()+"\n"+CD.ToString());
    }
    
    void Move()
    {
        Arotate = false;
        Brotate = false;
        Crotate = false;
        Drotate = false;
        
        humanA.GetComponent<PlayerBehavior>().CharacterMoving(7f);
        humanB.GetComponent<PlayerBehavior>().CharacterMoving(7f);
        humanC.GetComponent<PlayerBehavior>().CharacterMoving(7f);
        humanD.GetComponent<PlayerBehavior>().CharacterMoving(7f);
        
    }
}
