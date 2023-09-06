using System.Collections;
using System.Collections.Generic;
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

    private float checkTime = 3f;
    private bool canMove = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }
        
        if (canMove)
        {
            if (Input.GetKey(playerAleft))
            {
                humanA.GetComponent<PlayerBehavior>().RotateTheView(-1);
            }else if (Input.GetKey(playerAright))
            {
                humanA.GetComponent<PlayerBehavior>().RotateTheView(1);
            }
        
            if (Input.GetKey(playerBleft))
            {
                humanB.GetComponent<PlayerBehavior>().RotateTheView(-1);
            }else if (Input.GetKey(playerBright))
            {
                humanB.GetComponent<PlayerBehavior>().RotateTheView(1);
            }

            if (Input.GetKey(playerCleft))
            {
                humanC.GetComponent<PlayerBehavior>().RotateTheView(-1);
            }else if (Input.GetKey(playerCright))
            {
                humanC.GetComponent<PlayerBehavior>().RotateTheView(1);
            }

            if (Input.GetKey(playerDleft))
            {
                humanD.GetComponent<PlayerBehavior>().RotateTheView(-1);
            }else if (Input.GetKey(playerDright))
            {
                humanD.GetComponent<PlayerBehavior>().RotateTheView(1);
            }
        }
        

        checkTime -= Time.deltaTime;
        Debug.Log(checkTime.ToString());

        if (checkTime <= 0)
        {
            canMove = false;
            humanA.GetComponent<PlayerBehavior>().CharacterMoving(100f);
            humanB.GetComponent<PlayerBehavior>().CharacterMoving(50f);
            humanC.GetComponent<PlayerBehavior>().CharacterMoving(150f);
            humanD.GetComponent<PlayerBehavior>().CharacterMoving(75f);
            checkTime = 3f;
        }
    }
}
