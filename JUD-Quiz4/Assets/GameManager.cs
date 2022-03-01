using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public float LevelTime;
    [SerializeField]
    public int Lives;

    public TextMeshProUGUI timeUI;

    public List<GameObject> enemies;

    public bool gameOver;
    public bool gameWon;
    public bool GameLose;

    public List<GameObject> livesUI = new List<GameObject>();
    //public GameObject healthUI;
    //public Transform parent;
    //public Transform startPos;
    

    // Start is called before the first frame update
    void Start()
    {
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemies"));
        SetLives();
    }

    // Update is called once per frame
    void Update()
    {

        LevelTime -= Time.deltaTime;

        timeUI.text = ((int)LevelTime).ToString();
        if (LevelTime <= 0)
        {
            gameOver = true;
            LevelTime = 0;
            SceneManager.LoadScene(0);  
        }

        if(CheckList())
        {
            gameWon = true;
        }
        if (gameWon)
        {
            //GameObject.Find("MenuManager").GetComponent<MenuManager>().LevelPassed = SceneManager.GetActiveScene().buildIndex;
            //GameObject.Find("MenuManager").GetComponent<MenuManager>().StartCoroutine("WaitforTime",SceneManager.GetActiveScene().buildIndex);
            //MenuManager.LevelPassed++;
            MenuManager.instance.LevelPassed++;
            SceneManager.LoadScene(0);
        }
        else if (Lives < 0)
        {
            SceneManager.LoadScene(0);
        }


    }
    bool CheckList()
    {
        if(GameObject.FindGameObjectWithTag("Enemies") == null)
        {
            return true;
        }
        return false;
    }
    public void SetLives()
    {
        if(Lives > -1)
        Lives--;

        UpdateLives();
    }
    void UpdateLives()
    {
        //livesUI = 
        foreach (GameObject obj in livesUI)
        {
            obj.SetActive(false);
        }
        for(int i = 0; i <= Lives; i++)
        {
            livesUI[i].SetActive(true);
            //GameObject imageClone = Instantiate(healthUI, startPos.position, startPos.rotation);
            //imageClone.gameObject.transform.SetParent(parent, false);
            //imageClone.transform.position += new Vector3(40, transform.position.y, transform.position.z);
            //livesUI.Add(imageClone);
        }

    }
}
