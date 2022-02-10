using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public int PlayerCount = 1;
    void Start()
    {
        
    }
    public bool checkIfPlayerOne()
    {
        if (PlayerCount % 2 == 0)
        {
            return true;

        }
        else
            return false;
    }
    public void ChangeTurn()
    {
        //Debug.Log(PlayerCount);
        //Debug.Log(checkIfPlayerOne());

        PlayerCount++;
    }
}
