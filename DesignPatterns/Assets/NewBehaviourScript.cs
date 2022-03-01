using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int health;
    public static int totalNumber;


    // Start is called before the first frame update
    void Start()
    {
        NewBehaviourScript one = new NewBehaviourScript();
        one.health = 20;
        NewBehaviourScript.totalNumber = 100;
        NewBehaviourScript two = new NewBehaviourScript();
        two.health = 40;
        if (health != null)
            Debug.Log(health);
        else
            Debug.Log("is Null");

        Debug.Log(one.health);
        Debug.Log(two.health);
        Debug.Log(NewBehaviourScript.totalNumber);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
