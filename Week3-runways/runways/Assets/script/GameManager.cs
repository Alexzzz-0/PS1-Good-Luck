using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI retryTimes;
    [SerializeField] private Transform foot;

    [SerializeField] private Transform rope1;
    [SerializeField] private Transform rope2;
    [SerializeField] private Transform rope3;

    //private LineRenderer _lineRenderer;

    private Vector3[] linePos = new Vector3[3];
    
    private int tryTimes;
    
    private string folder_dir;
    private string file_dir;
    private string textFromFile;
    
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
        

        //_lineRenderer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Retry();
        }
        
        if (foot.position.y <= -5f)
        {
            Retry();
        }

        // linePos[0] = rope1.position;
        // linePos[1] = rope2.position;
        // linePos[2] = rope3.position;
        
        //_lineRenderer.SetPositions(linePos);
    }
    
    void Retry()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);

        tryTimes += 1;
        retryTimes.text = "Retry: " + tryTimes.ToString();
        
        File.WriteAllText(file_dir,tryTimes.ToString());
    }
    
}
