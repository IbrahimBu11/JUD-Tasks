using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HandleButton : MonoBehaviour
{
    public List<Button> buttons;

    void Start()
    {
        
        for (int i = 0; i < MenuManager.instance.LevelPassed; i++)
        {   if(i != -1 )
            buttons[i].interactable = true;
            Debug.Log("Works");
        }
    }
    public void LevelLoad(int index)
    {
        SceneManager.LoadScene(index);
    }
}
