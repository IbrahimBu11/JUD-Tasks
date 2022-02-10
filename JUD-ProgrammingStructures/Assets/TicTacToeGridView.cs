using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeGridView : MonoBehaviour
{
    public int row = 2;
    public int col = 2;

    public Image Prefab;
    public Transform parentUI;
    float offsetX = 350f;
    float offsetY = 250f;

    public float gridSizeHorizontal = 30.0f;
    public float gridSizeVertical = 30.0f;
    TicTacToeGrid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new TicTacToeGrid(row, col);
        grid.cellCreated += CellIntake;
       // grid.Display();
        grid.MakeAGridMatrix();
           
        //InitializeGridView();
        
    }
     void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        
            
    }

    void CellIntake(CellNonMono cell)
    {
       // Debug.Log("Works");


        Image image = Instantiate(Prefab, transform.position, Prefab.transform.rotation, parentUI);
        image.GetComponent<CellMono>().SetCell(cell);
        float posX = cell.col * gridSizeHorizontal + offsetX;
        float posY = cell.row * gridSizeVertical + offsetY;
        image.transform.position = new Vector3(posX, posY, 0);
    }



    void InitializeGridView()
    {

        for (int i = 0; i < grid.numOfRows; i++)
        {

            for (int j = 0; j < grid.numbOfColoumns; j++)
            {
                Image image = Instantiate(Prefab, transform.position, Prefab.transform.rotation, parentUI);

                float posY = j * gridSizeHorizontal + offsetX; //* gridSize) ; // * gridSize;
                float posX = i * gridSizeVertical + offsetY;//* -gridSize) ; // * gridSize;

                image.transform.position = new Vector3(posX, posY, 0);
                //image.transform.position += offset;

            }
            //float gridH = grid.numOfRows * gridSize;
            // float gridV = grid.numbOfColoumns * gridSize;

            //parentUI.transform.position = new Vector3(gridH/2 + gridSize/2, gridV/2 - gridSize/2);


            //offset += new Vector3(Prefab.transform.position.x, verticalSpacing, Prefab.transform.position.z);
            //offset = new Vector3(initialoffsetx, Prefab.transform.position.y, Prefab.transform.position.z);

        }
    }



}