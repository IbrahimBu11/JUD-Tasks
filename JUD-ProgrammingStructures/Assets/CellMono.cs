using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CellMono : MonoBehaviour, IPointerDownHandler
{

    public InputManager input;


    public Sprite tick;
    public Sprite cross;

    

    public int row;
    public int col;

    //public PlayerInput playerInput = { }

    Image image;
    CellNonMono CellNonMono;

    


    private void Update()
    {
        if(CellNonMono.status == Status.Tick )
        {
            image.sprite = tick;          
        }
        else if (CellNonMono.status == Status.Cross )
        {
            image.sprite = cross;
        }


        
    }

    void Start()
    {
        image = GetComponent<Image>();
        input = GameObject.Find("InputManager").GetComponent<InputManager>();
        
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
        
        if(CellNonMono.status != Status.Tick && CellNonMono.status != Status.Cross && input.IsGameOver != true) 
        { 
          CellNonMono.Interaction(input.checkIfPlayerOne());
          input.ChangeTurn();
        }

    }

}
