using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //public Button button2, button3, button4, button5;

    public static MenuManager instance = null;

    [SerializeField]
    public int LevelPassed = -1;

    private void Awake()
    {
        
        //SingleTon

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
           Destroy(gameObject);


        DontDestroyOnLoad(this.gameObject);
       // DontDestroyOnLoad(this);
        //OnSceneLoad(0);

    }




    


}
