using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monoCell : MonoBehaviour
{
    public int row;
    public int col;
    public Status status;
   
    CellNonMono CellNonMono;



    public void Update()
    {
        if (status == Status.Wall)
            GetComponent<MeshRenderer>().material.color = Color.red;
        else if (status == Status.empty)
            GetComponent<MeshRenderer>().material.color = Color.white;

    }
    public void SetCell(CellNonMono cell)
    {
        this.CellNonMono = cell;
        row = cell.row;
        col = cell.col;
        status = cell.status;
    }
    public void SetStatus(Status status)
    {
        CellNonMono.status = status;
    }

}
