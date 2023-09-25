using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI retryTimes;
    [SerializeField] private TextMeshProUGUI force;
    [SerializeField] private TextMeshPro W;
    [SerializeField] private TextMeshPro A;
    [SerializeField] private TextMeshPro S;
    [SerializeField] private TextMeshPro D;
    
    [SerializeField] private Transform foot;

    [SerializeField] private test _big;
    [SerializeField] private test _other;

    // [SerializeField] private Transform rope1;
    // [SerializeField] private Transform rope2;
    // [SerializeField] private Transform rope3;

    //private LineRenderer _lineRenderer;

    //private Vector3[] linePos = new Vector3[3];
    
    private int tryTimes;
    
    private string folder_dir;
    private string file_dir;
    private string textFromFile;
    

    private bool hasFade = false;
    
    // Start is called before the first frame update
    void Start()
    {
        #region Read Times From File

        folder_dir = Application.dataPath + "/Data/";

        if (!Directory.Exists(folder_dir))
        {
            Directory.CreateDirectory(folder_dir);
        }

        file_dir = folder_dir + "Data.txt";

        if (File.Exists(file_dir))
        {
            textFromFile = File.ReadAllText(file_dir);
            tryTimes = int.Parse(textFromFile);
        }
        else
        {
            tryTimes = 0;
        }

        retryTimes.text = "Retry: " + tryTimes.ToString();

        #endregion

        hasFade = false;

        

        //_lineRenderer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Retry();
        }
        
        //if falling down
        if (foot.position.y <= -5f)
        {
            Retry();
        }
        

        //disappear the instructions
        if (!hasFade)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                DisappearInstrcutions();
            }
        }

        //adjust the force
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _big.speed = 10f;
            _other.speed = 10f;
            force.text = "Force: " + _big.speed.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _big.speed = 109f;
            _other.speed = 109f;
            force.text = "Force: " + _big.speed.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _big.speed = 208f;
            _other.speed = 208f;
            force.text = "Force: " + _big.speed.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _big.speed = 307f;
            _other.speed = 307f;
            force.text = "Force: " + _big.speed.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _big.speed = 406f;
            _other.speed = 406f;
            force.text = "Force: " + _big.speed.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _big.speed = 505f;
            _other.speed = 505f;
            force.text = "Force: " + _big.speed.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            _big.speed = 604f;
            _other.speed = 604f;
            force.text = "Force: " + _big.speed.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            _big.speed = 703f;
            _other.speed = 703f;
            force.text = "Force: " + _big.speed.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            _big.speed = 802f;
            _other.speed = 802f;
            force.text = "Force: " + _big.speed.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            _big.speed = 901f;
            _other.speed = 901f;
            force.text = "Force: " + _big.speed.ToString();
        }
        
    }
    
    void Retry()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);

        tryTimes += 1;
        retryTimes.text = "Retry: " + tryTimes.ToString();
        
        File.WriteAllText(file_dir,tryTimes.ToString());
    }

    void DisappearInstrcutions()
    {
        W.DOFade(0, 2f);
        A.DOFade(0, 2f);
        S.DOFade(0, 2f);
        D.DOFade(0, 2f);
    }
    
}
