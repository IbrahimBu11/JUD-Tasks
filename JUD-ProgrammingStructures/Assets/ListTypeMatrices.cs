using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListTypeMatrices 
{

    public TextMeshProUGUI text;
    public int numOfRows;
    public int numbOfColoumns;

    public List<List<int>> matrixList;


    //   public List<List<int>> TestMatrix;




    public ListTypeMatrices(int row, int col)
    {
        this.numOfRows = row;
        this.numbOfColoumns = col;
        this.matrixList = new List<List<int>>();
        MakeaMatrixList();

    }
    virtual public  List<List<int>> MakeaMatrixList()
    {

        //matrixList = new List<List<int>>();
        for (int i = 0; i < numOfRows; i++)
        {
            matrixList.Add(new List<int>());

            for (int j = 0; j < numbOfColoumns; j++)
            {
                matrixList[i].Add(0);
            }
        }
        return matrixList;
    }

    public void PrintMatrixList()
    {
        string yo = "";
        for (int i = 0; i < numOfRows; i++)
        {

            for (int j = 0; j < numbOfColoumns; j++)
            {
                yo += matrixList[i][j].ToString() + " ";

            }
            yo += "\n";
        }
        Debug.Log(yo);
    }
    public void SetElement(int row, int col, int num)
    {
        matrixList[row][col] = num;
    }
    public void SetAllElement(int num)
    {
        for (int i = 0; i < matrixList.Count; i++)
        {
            for (int j = 0; j < matrixList[i].Count; j++)
            {

                matrixList[i][j] = num;
            }


        }
    }
    public int GetElement(int row, int col)
    {
        //matrix.GetValue(matrix[row, col]);
        return matrixList[row][col];
    }
    public void SetRow(int rowToSet, int rowToBeSetWith)
    {
        for (int j = 0; j < numOfRows; j++)
        {
            matrixList[rowToSet][j] = rowToBeSetWith;
        }
    }

    public void SetCol(int colToSet, int colToBeSetWith)
    {
        for (int j = 0; j < numbOfColoumns; j++)
        {
            matrixList[j][colToSet] = colToBeSetWith;
        }
    }

    public void SwapRow(int rowToSwap, int RowToBeSwappedWith)
    {
        int[] tempRow = new int[numOfRows];

        for (int i = 0; i < numOfRows; i++)
        {
            tempRow[i] = matrixList[rowToSwap][i];
            matrixList[rowToSwap][i] = matrixList[RowToBeSwappedWith][i];
            matrixList[RowToBeSwappedWith][i] = tempRow[i];
        }
    }

    public void SwapCol(int colToSwap, int colToBeSwappedWith)
    {
        int[] tempCol = new int[numbOfColoumns];

        for (int i = 0; i < numbOfColoumns; i++)
        {
            tempCol[i] = matrixList[i][colToSwap];
            matrixList[i][colToSwap] = matrixList[i][colToBeSwappedWith];
            matrixList[i][colToBeSwappedWith] = tempCol[i];
        }
    }

    public List<List<int>> AddMatrices(List<List<int>> listToAdd)
    {
        List<List<int>> tempMatrix = listToAdd;
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numbOfColoumns; j++)
            {
                tempMatrix[i][j] = matrixList[i][j] + listToAdd[i][j];
            }
        }

        matrixList = tempMatrix;
        return matrixList;
    }
    public List<List<int>> SubMatrices(List<List<int>> listToSub)
    {
        List<List<int>> tempMatrix = listToSub;
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numbOfColoumns; j++)
            {
                tempMatrix[i][j] = listToSub[i][j] - matrixList[i][j];
            }
        }

        matrixList = tempMatrix;
        return matrixList;
    }

    public void SetDiagnol(int num)
    {
        int indexer = 0;
        for (int i = 0; i < numOfRows; i++)
        {
            matrixList[i][indexer] = num;
            indexer += 1;
        }

    }
    public void SetInverseDiagnol(int num)
    {
        Debug.Log(numOfRows);
        int indexer = numOfRows - 1;
        Debug.Log(indexer);
        for (int i = 0; i < numOfRows; i++)
        {
            matrixList[i][indexer] = num;
            indexer -= 1;
        }
    }

    public bool isDiagnolSame()
    {
        int sameNum = matrixList[0][0];
        int indexer = 0;
        bool[] same = new bool[numOfRows];
        bool isSame = false;
        for (int i = 0; i < numOfRows; i++)
        {
            if (matrixList[i][i] == sameNum) {
                //isSame = true;
                //sameNum = matrixList[i][indexer];
                same[i] = true;
            }
            else //if (matrixList[i][indexer] != sameNum)
            {
                same[i] = false;
            }

            indexer += 1;
        }
        for (int i = 0; i < same.Length; i++)
        {
            if (same[i] == false)
                isSame = false;
            else
                isSame = true;
        }
        return isSame;


    }
    public bool isInverseDiagnol()
    {
        int sameNum = matrixList[0][0];
        int indexer = numbOfColoumns;
        bool[] same = new bool[numbOfColoumns];
        bool isSame = false;
        for (int i = 0; i < numbOfColoumns; i++)
        {
            if (matrixList[i][indexer] == sameNum)
            {
                //isSame = true;
                //sameNum = matrixList[i][indexer];
                same[i] = true;
            }
            else //if (matrixList[i][indexer] != sameNum)
            {
                same[i] = false;
            }

            indexer -= 1;
        }
        for (int i = 0; i < same.Length; i++)
        {
            if (same[i] == false)
                isSame = false;
            else
                isSame = true;
        }
        return isSame;
    }

    public bool isRowSame(int num)
    {
        int sameNum = matrixList[0][0];
        
        bool[] same = new bool[numOfRows];
        bool isSame = false;
        for (int i = 0; i < numOfRows; i++)
        {
            if (sameNum == matrixList[num][i])
                same[i] = true;
            else
                same[i] = false;
        }
        for (int i = 0; i < same.Length; i++)
        {
            if (same[i] == false)
                isSame = false;
            else
                isSame = true;
        }
        return isSame;
    }
    public bool isColSame(int num)
    {
        int sameNum = matrixList[0][0];

        bool[] same = new bool[numbOfColoumns];
        bool isSame = false;
        for (int i = 0; i < numbOfColoumns; i++)
        {
            if (sameNum == matrixList[i][num])
                same[i] = true;
            else
                same[i] = false;
        }
        for (int i = 0; i < same.Length; i++)
        {
            if (same[i] == false)
                isSame = false;
            else
                isSame = true;
        }
        return isSame;
    }

    public float[] GetRow(int rowIndex)
    {
        float[] tempFloat = new float[numOfRows];

        for (int j = 0; j < numOfRows; j++)
        {
            tempFloat[j] = matrixList[rowIndex][j] ;
        }

        return tempFloat;
    }
    public float[] GetCol(int colIndex)
    {
        float[] tempFloat = new float[numOfRows];

        for (int j = 0; j < numOfRows; j++)
        {
            tempFloat[j] = matrixList[j][colIndex];
        }

        return tempFloat;
    }

    public void Multiply(List<List<int>> matrixToMultiplyWith)
    {
        List<List<int>> resultMatrix = new List<List<int>>();
        for (int i = 0; i < numOfRows; i++)
        {
            resultMatrix.Add(new List<int>());
            for (int j = 0; j < numbOfColoumns; j++)
            {
                resultMatrix[i].Add(0);
                for (int k = 0; k < numbOfColoumns; k++)
                {
                    resultMatrix[i][j] += matrixList[i][k] * matrixToMultiplyWith[k][j];
                }
            }
        }
    }





    void Start()
    {


        //ListTypeMatrices listMatrix1 = new ListTypeMatrices(2, 2);
        //ListTypeMatrices listMatrix2 = new ListTypeMatrices(5, 5);

        //listMatrix1.MakeaMatrixList();
        //listMatrix2.MakeaMatrixList();

        //Debug.Log(listMatrix1.matrixList[1].Count.ToString());
       // Debug.Log(matrixList[0].Count);

        

        //listMatrix1.SetAllElement(3);
        //listMatrix2.SetAllElement(2);

        // listMatrix2.SetDiagnol(6);
        //listMatrix2.SetDiagnol(-6);
        //listMatrix2.SetRow(1, 11);
        //Debug.Log(listMatrix2.isDiagnolSame());


        // listMatrix1.SetRow(0, 1);
        //listMatrix1.SetCol(1, 1);
        //listMatrix1.SwapCol(0, 1);
        //listMatrix1.SetElement(0, 1, 10);
        //Debug.Log(listMatrix1.GetElement(0, 1));
        //listMatrix2.PrintMatrixList();
        //listMatrix1.SubMatrices(listMatrix2.matrixList);
        //listMatrix2.Multiply(listMatrix1.matrixList);

        //float[] floatray = listMatrix2.GetRow(1);
        //for (int i = 0; i < floatray.Length; i++)
        //{
        //    string t = "";
        //    t += floatray[i].ToString();
        //    Debug.Log(t);
        //}

        //listMatrix2.PrintMatrixList();

    }





}


