using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameOver(bool gameOver);
public delegate void OnCellCreated(CellNonMono cell);
public class TicTacToeGrid : ListTypeMatrices
{
    public List<List<CellNonMono>> matrix;
    public InputManager input;


    //public bool isDraw = false;
   // public bool isWon= false;
    
    public OnCellCreated cellCreated;    
    public GameOver gamover;



    public TicTacToeGrid(int row, int col) : base(row, col)
    {
        //MakeAMatrixInGrid();
        
    }
    public List<List<CellNonMono>> MakeAGridMatrix()
    {
      //  Debug.Log("Methos starts");
        matrix = new List<List<CellNonMono>>();

        for (int i = 0; i < numOfRows; i++)
        {

            matrix.Add(new List<CellNonMono>());
            for (int j = 0; j < numbOfColoumns; j++)
            {
                CellNonMono tempCell = new CellNonMono(i, j);

                matrix[i].Add(tempCell);
                cellCreated.Invoke(tempCell);
                tempCell.statusUpdated += OnInteraction;
               // Debug.Log("Loop works");        
                //tempCell.statusUpdated += OnStatusUpdate;
                //tempCell. += OnStatusUpdate;
            }
        }
        return matrix;
    }
    void SyncWithListMatrix(int row, int col)
    {
        //for (int i = 0; i < numOfRows; i++)
        //{
            //for (int j = 0; j < numbOfColoumns; j++)
            //{
                base.matrixList[row][col] = (int)matrix[row][col].status;
        //    }
        //}
        
    }
    public  void OnInteraction(int row, int col, Status status)
    {
       // Debug.Log(input.IsGameOver);
        //input.SetText();
        this.matrix[row][col].status = status;
        SyncWithListMatrix(row, col);
        
        PrintMatrixList();
        if (matrix[row][col].status != Status.Clickable) 
        {
           // Debug.Log("Working for no reason");
            if (CheckWin(row, col))
            {
                Debug.Log("Somebody Won, Cant really tell since i cant fucking communicate with mono script");
            }
            else if (CheckDraw())
            {
                //isDraw = true;
                Debug.Log("Its a draw you both suck");
            }
        }

    }
    public bool  CheckWin(int row, int col)
    {
        bool temp = false;
        //
        if (isDiagnolSame() || isRowSame(row) || isColSame(col) || isInverseDiagnol())//  ||
        {
            temp = true;
            Debug.Log("Diagnol : " + isDiagnolSame());
            Debug.Log("InverseDiagnol : " + isInverseDiagnol());
            Debug.Log("Row : " + isRowSame(row));
            Debug.Log("Col: " + isColSame(col));
        }
        else
            temp = false;
        
        return temp;
    }
    public bool CheckDraw()
    {
        bool temp = false;
        if (CheckIfAllFilled())
        {
            temp = true;
        }
        else
            temp = false;

        return temp;
    }
    public bool CheckIfAllFilled()
    {
        bool allFilled = false;
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numbOfColoumns; j++)
            {
                if (matrix[i][j].status != Status.Clickable)
                    allFilled = true;
                else
                    allFilled = false;
                                
            }
        }
        return allFilled;
    }
    

     void Start()

     {
       // MakeAMatrixInGrid();
        Debug.Log(matrix.ToString());
     }



}
