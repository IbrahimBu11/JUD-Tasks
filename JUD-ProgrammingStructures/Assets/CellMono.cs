using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CellMono : MonoBehaviour, IPointerDownHandler
{
    

    public int row;
    public int col;

    //public PlayerInput playerInput = { }

    Image image;
    CellNonMono CellNonMono;

    int PlayerCount = 1;
    bool checkIfPlayerOne()
    {
        if (PlayerCount % 2 == 0)
        {
            return true;
            
        }
        else 
            return false;
    }

    private void Update()
    {
        if(CellNonMono.status == Status.Red)
        {
            image.color = Color.red;
        }
        else if (CellNonMono.status == Status.Blue)
        {
            image.color = Color.blue;
        }
    }
    void Start()
    {
        image = GetComponent<Image>();
        
    }
    public void SetCell(CellNonMono cell)
    {
        this.CellNonMono = cell;
    }
    public void SetStatus(Status status)
    {
        CellNonMono.status = status;       
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (CellNonMono.status != Status.Red && CellNonMono.status != Status.Blue)
        {
            CellNonMono.Interaction(checkIfPlayerOne());
            PlayerCount++;
        }

        
    }


}
