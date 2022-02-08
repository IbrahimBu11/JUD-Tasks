using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Matrices : MonoBehaviour
{
    // Start is called before the first frame update

    //public Text text;
    public ListTypeMatrices matrixList1;

    public TextMeshProUGUI text;
    public int numOfRows { get; set; }
    public int numbOfColoumns { get; set; }


    public List<List<int>> matrixList ;
    public int[,] matrix { get; set; }
    public int[,] matrix1;//= { { 2, 3 },{ 2, 3 } };

   //Make a matrix and populate it with 0
    int[,] MakeaMatrix(int row, int column)
    {        
        matrix = new int[row,column];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {

                matrix[i, j] = 0;
            }
        }
        return matrix;
    }
    new List<List<int>> MakeaMatrixList(int row, int column)
    {
        matrixList = new List<List<int>>();

        for (int i = 0; i < row; i++)
        {
            matrixList.Add(new List<int>());

            for (int j = 0; j < column; j++)
            {

                matrixList[i].Add(0);
            }
        }
        return matrixList;
    }



    //Print All the elements of a matrix
    void PrintMatrixList(List<List<int>> matrixList)
    {
        for (int i = 0; i < matrixList.Count; i++)
        {
            for (int j = 0; j < matrixList[i].Count; j++)
            {
                
                text.text += matrixList[i][j].ToString();
            }
            text.text += "\n";
            
        }
    }
    void PrintMatrix(List<List<int>> matrix)
    {
        for (int i = 0; i < matrixList.Count; i++)
        {
            for (int j = 0; j < matrixList.Count; j++)
            {

                text.text += matrixList[i][j];
            }
            text.text += "\n";
        }
    }
    //Set the given element to a number
    void SetElement(int row, int col, int num)
    {
        matrix[row, col] = num;        
    }
    //Set all elemnts to a certai number
    void SetAllElement(int num)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {

                matrix[i, j] = num;
            }
            

        }
    }
    //Get an element of respective iterations
    int GetElement(int row, int col)
    {
        //matrix.GetValue(matrix[row, col]);
        return matrix[row, col];
    }
    //Set a Row of a matrix with a given num
    void SetRow(int rowToSet, int rowToBeSetWith)
    {
            for(int j = 0; j < matrix.GetLength(0); j++)
            {
            matrix[rowToSet, j] = rowToBeSetWith; 
            }      
    }
    //Set a column of a matrix witha given num
    void SetCol(int colToSet, int colToBeSetWith)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            matrix[j, colToSet] = colToBeSetWith;
        }
    }
    //Swap the given row with another row
    void SwapRow(int rowToSwap, int RowToBeSwappedWith)
    {
        int[] tempRow = new int[matrix.GetLength(0)] ;

        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            tempRow[i] = matrix[rowToSwap, i];
            matrix[rowToSwap, i] = matrix[RowToBeSwappedWith, i];
            matrix[RowToBeSwappedWith, i] = tempRow[i];
        }
    }
    //Swap the given col with another col
    void SwapCol(int colToSwap, int colToBeSwappedWith)
    {
        int[] tempCol = new int[matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            tempCol[i] = matrix[i, colToSwap];
            matrix[i, colToSwap] = matrix[i, colToBeSwappedWith];
            matrix[i, colToBeSwappedWith] = tempCol[i];
        }
    }

    List<List<int>> AddMatrices(List<List<int>> matrixListTobeAdded)
    {
        List<List<int>> tempMatrix = new List<List<int>>();
        for(int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numbOfColoumns; j++)
            {
                tempMatrix[i][j] = matrixList[i][j] + matrixListTobeAdded[i][j];
            }
        }
        return tempMatrix;
    }
    int[,] SubtractMatrices(int[,] matrix1, int[,] matrix2)
    {
        int[,] tempMatrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.GetLength(0); j++)
            {
                tempMatrix[i, j] = matrix1[i, j] -= matrix2[i, j];
            }
        }
        return tempMatrix;
    }

    //Constructor
    Matrices(int row, int column)
    {
        numOfRows = row;
        numbOfColoumns = column;
    }
    void Start()
    {
        ListTypeMatrices matrixList1 = new ListTypeMatrices(2,2);

        //Debug.Log(matrixList1.numOfRows);

        matrixList1.MakeaMatrixList();
        matrixList1.PrintMatrixList();



      //  MakeaMatrixList(5, 6);
      //  Debug.Log(matrixList.Count.ToString() + matrixList[0].Count.ToString());
      //  MakeaMatrixList(3, 3);
      //  PrintMatrixList(matrixList);
      //  SetAllElement(4);
       // matrix1 = matrix;
        //matrix = AddMatrices(matrix, matrix1);      
        //matrix = SubtractMatrices(matrix, matrix1);      
      //  PrintMatrix(matrix);
        //PrintMatrix(matrixList);

        
    }



}
