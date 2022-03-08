using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnCellCreated(CellNonMono cell);
public class ControlMatrix : ListTypeMatrices
{


    public OnCellCreated cellCreated;
    public List<List<CellNonMono>> matrix;
    public ControlMatrix(int row, int col) : base(row, col)
    {
        //MakeABorder();
    }

    void MakeABorder()
    {
        
    }
    public List<List<CellNonMono>> MakeAMonoMatrix()
    {
        matrix = new List<List<CellNonMono>>();
        Debug.Log("Works");
        for (int i = 0; i < numOfRows; i++)
        {

            matrix.Add(new List<CellNonMono>());
            for (int j = 0; j < numbOfColoumns; j++)
            {
                CellNonMono tempCell = new CellNonMono(i, j);

                matrix[i].Add(tempCell);
                cellCreated.Invoke(tempCell);
               // tempCell.statusUpdated += OnInteraction;
                // Debug.Log("Loop works");        
                //tempCell.statusUpdated += OnStatusUpdate;
                //tempCell. += OnStatusUpdate;
            }
        }

        //Make a Border in control

        SetRowControl(0, Status.Wall);
        SetRowControl(numOfRows - 1, Status.Wall);
        SetColControl(0, Status.Wall);
        SetColControl(numbOfColoumns - 1, Status.Wall);

        sync();

        Debug.Log("Works");
        return matrix;
    }
    public void SetRowControl(int rowToSet, Status status)
    {
        for (int j = 0; j < numbOfColoumns; j++)
        {
            matrix[rowToSet][j].status = status;
        }
    }

    public void SetColControl(int colToSet, Status status)
    {
        for (int j = 0; j < numOfRows; j++)
        {
            matrix[j][colToSet].status = status;
        }
    }
    public void sync()
    {
        for (int i = 0; i < numOfRows; i++)
        {           
            for (int j = 0; j < numbOfColoumns; j++)
            {
                matrixList[i][j] = (int)matrix[i][j].status;               
            }
        }
    }
    public void OnInteraction(int row, int col, Status status)
    {

    }

}
