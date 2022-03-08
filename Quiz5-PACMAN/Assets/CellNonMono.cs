using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Statusses { Wall, empty};

public class CellNonMono : MonoBehaviour
{


    public delegate void StatusUpdated(int row, int col, Statusses status);
    public StatusUpdated statusUpdated;


    public Statusses status = Statusses.empty;

    public int row;
    public int col;

    public CellNonMono(int row, int col)
    {
        this.row = row;
        this.col = col;
        this.status = Statusses.empty;
    }
     

    public void SetStatus(Statusses status)
    {
        this.status = status;
    }
    Statusses GetStatus(Statusses status)
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
