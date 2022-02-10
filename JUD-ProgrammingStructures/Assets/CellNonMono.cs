using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status {Clickable, Red, Blue};

public class CellNonMono 
{


    public delegate void StatusUpdated(int row, int col, Status status);
    public StatusUpdated statusUpdated;
    

    public Status status = Status.Clickable;

    public int row;
    public int col;

    public CellNonMono(int row, int col)
    {
        this.row = row;
        this.col = col;
        this.status = Status.Clickable;
    }
    
    public void Interaction(bool isPlayerOne)
    {
        if (isPlayerOne)
            statusUpdated.Invoke(row, col, Status.Red);
        else if (!isPlayerOne)
            statusUpdated.Invoke(row, col, Status.Blue);
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
