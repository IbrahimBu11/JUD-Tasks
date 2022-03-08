using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status { Wall, empty};

public class CellNonMono
{


    public delegate void StatusUpdated(int row, int col, Status status);
    public StatusUpdated statusUpdated;


    public Status status = Status.empty;

    public int row;
    public int col;

    public CellNonMono(int row, int col)
    {
        this.row = row;
        this.col = col;
        this.status = Status.empty;
    }

    void SetStatus(Status status)
    {
        this.status = status;
    }
    Status GetStatus(Status status)
    {
        return status;
    }

    void SetRowCol(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
    int GetRow()
    {
        return row;
    }
    int GetCol()
    {
        return col;
    }







}
