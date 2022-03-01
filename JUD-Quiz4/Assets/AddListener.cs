using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AddListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Button but = this.gameObject.GetComponent<Button>();
        //but.onClick.AddListener();
    }

    public void LoadScenef(int index)
    {
        SceneManager.LoadScene(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
