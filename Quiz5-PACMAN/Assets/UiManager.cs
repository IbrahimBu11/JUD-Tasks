using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public float TotalTime;
    public float elapsedTme;


    public int numOfLives;

    public TextMeshProUGUI text;
    public TextMeshProUGUI Lives;
    public TextMeshProUGUI percentage;
    public TextMeshProUGUI YouWin;

    public GameManagerSimple manager;




    private void Start()
    {
        elapsedTme = TotalTime;
        
    }
    private void Update()
    {
        if(elapsedTme > 0)
        elapsedTme -= Time.deltaTime;

        text.SetText("Time Remaining : " + elapsedTme);
        Lives.SetText("Lives Remaining : " + numOfLives);
        percentage.SetText("Percentage Completed" + manager.CheckCompletion());

        if(manager.CheckCompletion() >= 70)
        {
            YouWin.enabled = true;
            Debug.Log("Works");
        }
    }

}
