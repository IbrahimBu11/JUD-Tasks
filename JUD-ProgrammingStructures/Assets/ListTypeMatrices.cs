using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListTypeMatrices : MonoBehaviour
{

    public TextMeshProUGUI text;
    private int numOfRows;
    private int numbOfColoumns;

    public List<List<int>> matrixList ;


 //   public List<List<int>> TestMatrix;




    public ListTypeMatrices(int row, int col)
    {
        this.numOfRows = row;
        this.numbOfColoumns = col;
        this.matrixList = new List<List<int>>();
        //MakeaMatrixList(row, col);

    }
    public List<List<int>> MakeaMatrixList()
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
        for (int i = 0; i < numOfRows; i++)
        {
            
            for (int j = 0; j < numbOfColoumns; j++)
            {
                text.text += matrixList[i][j].ToString();
            }
            text.text += "\n";
        }
    }

     void Start()
    {

        //MakeaMatrixList();
        ListTypeMatrices listMatrix1 = new ListTypeMatrices(2, 2);

        //    Debug.Log(numbOfColoumns + numOfRows);
        //TestMatrix = listMatrix1.matrixList;
        //    //listMatrix1.MakeaMatrixList(2,2);
        listMatrix1.MakeaMatrixList();

        //listMatrix1.matrixList = MakeaMatrixList() ;
        //listMatrix1.matrixList.Add(new List<int>());
        //listMatrix1.matrixList[0].Add(5);

        //Debug.Log(listMatrix1.matrixList[0][0].ToString());
        //for (int i = 0; i < numOfRows; i++)
        //{
        //    listMatrix1.matrixList.Add(new List<int>());

        //    for (int j = 0; j < numbOfColoumns; j++)
        //    {
        //        listMatrix1.matrixList[i].Add(0);
        //    }
        //}
        listMatrix1.PrintMatrixList();



        //   // PrintMatrixList(matrixList);
    }





}


