using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGrid : ListTypeMatrices
{
    public List<List<CellNonMono>> matrix;

    public delegate void OnCellCreated(CellNonMono cell);
    public OnCellCreated cellCreated;



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
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numbOfColoumns; j++)
            {
                base.matrixList[i][j] = (int)matrix[i][j].status;
            }
        }
        
    }
    public virtual void OnInteraction(int row, int col, Status status)
    {
        this.matrix[row][col].status = status;
        SyncWithListMatrix(row, col);
        
        PrintMatrixList();
        if(matrixList[row][col] != 0)
        CheckWin(row, col);
    }
    public void  CheckWin(int row, int col)
    {
        
        if (isDiagnolSame()  || isRowSame(row) || isColSame(col))
        {
            Debug.Log("You  have won");
        }
    }
    

     void Start()

     {
       // MakeAMatrixInGrid();
        Debug.Log(matrix.ToString());
     }



}
