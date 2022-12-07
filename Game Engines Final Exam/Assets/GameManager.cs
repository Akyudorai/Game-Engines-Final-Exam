using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{   
    // Singleton
    private static GameManager instance;
    public static GameManager GetInstance() { return instance; }

    [Header("UI")]
    public GameObject GamePanel;
    public TMP_Text ScoreDisplay;
    public GameObject WinPanel;
    public GameObject LossPanel;

    [Header("Game Variables")]
    public int Score;

    [Header("Object Pooling")]     
    public GameObject ghostPrefab;
    public GameObject pelletPrefab;
    private ObjectPool ghostObjectPool;
    private ObjectPool pelletObjectPool;

    private void Awake() 
    {   
        // If the instance does not exist, set it equal to this object
        if (instance == null) {
            instance = this;
        } 

        // If instance already exists, destroy the duplicate object.
        else  {
            Destroy(this.gameObject);
        }

        // Load Object Pools
        ghostObjectPool = ObjectPool.Initialize(ghostPrefab, 4);
        pelletObjectPool = ObjectPool.Initialize(pelletPrefab, 64);
    }

    public void Start() 
    {
        PopulatePellets();
        StartCoroutine(PeriodicLoadGhost());
    }

    public void PopulatePellets()
    {         
        for (int i = 0; i < 8; i++)
        {                
            for (int j = 0; j < 8; j++) 
            {                                   
                GameObject pellet = pelletObjectPool.GetObjectFromPool();
                pellet.transform.position = new Vector3((-4) + i, (-4) + j);
                pellet.SetActive(true);
            }
        }
    }    

    public void AddPoint() 
    {
        Score++;
        ScoreDisplay.text = "Score: " + Score.ToString();

        // Game Win Event Trigger
        if (Score >= 64) {
            TriggerWin();
        }
    }

    public void RemovePoint() 
    {
        Score--;
        ScoreDisplay.text = "Score: " + Score.ToString();
    }

    public IEnumerator PeriodicLoadGhost() 
    {
        float timeBetweenEachGhost = 2.0f;
        GameObject ghostObject;
        
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(timeBetweenEachGhost);

            ghostObject = ghostObjectPool.GetObjectFromPool();
            ghostObject.transform.position = new Vector3((-4)+i*2, 4.5f, 0);
            ghostObject.SetActive(true);
        }
    }

    public void TriggerWin()
    {
        GamePanel.SetActive(false);
        WinPanel.SetActive(true);
    }

    public void TriggerLose() 
    {
        GamePanel.SetActive(false);
        LossPanel.SetActive(true);
    }

    public void Quit() 
    {
        Application.Quit();
    }
}
