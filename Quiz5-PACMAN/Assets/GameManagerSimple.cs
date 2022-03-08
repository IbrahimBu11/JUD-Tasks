using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSimple : MonoBehaviour
{
    public int row = 5;
    public int col = 5;


    //public int walls = 0;
    private float gap = 1.1f;

    public GameObject prefab;

    public List<List<GameObject>> matrixList;

    private void Start()
    {
        MakeaList();
    }

    public float CheckCompletion()
    {
        float percentage = 0;
        int walls = 0;
        int totalCount = row * col;
        //walls = 0;
        for (int i = 0; i < row; i++)
        {
            
            for (int j = 0; j < col; j++)
            {
                if (matrixList[i][j].GetComponent<monoCellSimple>().status == Status.wall) { 
                    walls++;
                    Debug.Log(walls);
                }
            }
        }
        Debug.Log(totalCount);
        percentage = (walls / totalCount) * 100;
       // Debug.Log(percentage);
        return walls ;
    }

    void MakeaList()
    {
        matrixList = new List<List<GameObject>>();
        for (int i = 0; i < row; i++)
        {
            matrixList.Add(new List<GameObject>());
            for (int j = 0; j < col; j++)
            {
                matrixList[i].Add(CellIntake(i, j));
            }
        }
        //Making a border
        SetRowControl(0, Status.wall);
        SetRowControl(row -1 , Status.wall);
        SetColControl(0, Status.wall);
        SetColControl(col-1 , Status.wall);
    }

    void SetCell(int row, int col, Status status)
    {      
        matrixList[row][col].GetComponent<monoCellSimple>().SetCell(status);
    }
    public void SetRowControl(int rowToSet, Status status)
    {
        for (int j = 0; j < col; j++)
        {
            matrixList[rowToSet][j].GetComponent<monoCellSimple>().status = status;
        }
    }

    public void SetColControl(int colToSet, Status status)
    {
        for (int j = 0; j < row; j++)
        {
            matrixList[j][colToSet].GetComponent<monoCellSimple>().status = status;
        }
    }

    GameObject CellIntake(int row, int col)
    {
        GameObject cellMonoClone = Instantiate(prefab, transform.position, prefab.transform.rotation);

        cellMonoClone.GetComponent<monoCellSimple>().SetCell(row, col);

        float posX = row * gap;
        float posY = col * -gap;
        cellMonoClone.transform.position = new Vector3(posX, posY, 0);
        return cellMonoClone;

        //matrix.Add(cellMonoClone);
    }
}
