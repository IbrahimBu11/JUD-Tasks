using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour
{
    public int PlayerCount = 1;
    public TicTacToeGridView grid;

    public TextMeshProUGUI text;
    public TextMeshProUGUI GameWonText;
    public TextMeshProUGUI DrawText;

    
    public Sprite tick;
    public Sprite cross;




    public bool IsGameOver = false;
    void Start()
    {
        GameWonText.enabled = false;
        DrawText.enabled = false;
        //GameOver += gamover;
    }
     void Update()
    {
        SetText();
        //CheckWinOrDraw();
        
        if (IsGameOver)
        {
            if (Input.GetKey(KeyCode.R))
                SceneManager.LoadScene(0);
        }
    }
    //void CheckWinOrDraw()
    //{
    //    if (grid.grid.isWon)
    //    {
    //        Win();
    //    }
    //    else if (grid.grid.isDraw)
    //    {
    //        Draw();
    //    }
    //}
    public bool checkIfPlayerOne()
    {
        if (PlayerCount % 2 == 0)
        {
            return false;
        }
        else
            return true;
    }
    public void SetText()
    {
        text.SetText(CurrentPlayerName() + "'s  TURN" );
        text.transform.GetChild(0).GetComponent<Image>().sprite = CurrentPlayerSprite();
    }
    Sprite CurrentPlayerSprite()
    {
        Sprite tempSprite = tick;
        if (checkIfPlayerOne())
        {
            tempSprite = tick;
        }
        else
        {
            tempSprite = cross;
        }
        return tempSprite;
    }
    string CurrentPlayerName()
    {
        string tempName = ""; 
        if (checkIfPlayerOne())
        {
            tempName = "Player 1";
        }
        else
        {
            tempName = "Player 2"; 
        }
        return tempName;
    }

    public void Win()
    {
        IsGameOver = true;
        GameWonText.enabled = true;
        GameWonText.text = CurrentPlayerName() + " has Won \n" + "Press R To Restart Game";
        //GameWonText.color = CurrentPlayerSprite();
    }
    public void Draw()
    {
        IsGameOver = true;
        DrawText.enabled = true;
        GameWonText.text = "Game is Draw \n" + "Press R To Restart Game";
       // GameWonText.color = Color.black;

    }
    public void ChangeTurn()
    {
        //Debug.Log(PlayerCount);
        //Debug.Log(checkIfPlayerOne());

        PlayerCount++;
    }
}
