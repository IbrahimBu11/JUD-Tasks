using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Status { wall, empty, oncompletion }
public class monoCellSimple : MonoBehaviour
{
    

    public int row;
    public int col;
    public Status status = Status.empty;


    private void Update()
    {
        if (status == Status.wall)
            GetComponent<MeshRenderer>().material.color = Color.red;
        else if (status == Status.empty)
            GetComponent<MeshRenderer>().material.color = Color.white;
    }
    public void SetCell(int row, int col, Status status )
    {
        this.row = row;
        this.col = col;
        this.status = status;
    }
    public void SetCell(int row, int col)
    {
        this.row = row;
        this.col = col;
        
    }
    public void SetCell(Status status)
    {
        this.status = status;

    }


}
