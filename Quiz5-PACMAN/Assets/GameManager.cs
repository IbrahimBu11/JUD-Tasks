using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int row = 5;
    public int col = 5;

    private float gap = 1.1f;

    public ControlMatrix control;

    public GameObject player;

    public List<GameObject> matrix;

    public GameObject cellMono;

    // Start is called before the first frame update
    void Start()
    {
        control = new ControlMatrix(row, col);
        
        control.cellCreated += CellIntake;
        //control.PrintMatrixList();
        control.MakeAMonoMatrix();




        //control.sync();

        control.PrintMatrixList();
       // player.GetComponent<PlayerController>().posChange += OnUpdate;
    }
    void OnUpdate(int row, int col, Statusses status)
    {
        control.matrix[row][col].status = Statusses.Wall;
        control.sync();
        control.PrintMatrixList();

    }


    void CellIntake(CellNonMono cell)
    {
        GameObject cellMonoClone = Instantiate(cellMono, transform.position, cellMono.transform.rotation);

        Component cells = cell;
            
        //cellMonoClone.AddComponent<cell>();
        cellMonoClone.GetComponent<CellNonMono>().status = cell.status;
        float posX = cell.row *  gap;
        float posY = cell.col * -gap;
        cellMonoClone.transform.position = new Vector3(posX, posY, 0);

        matrix.Add(cellMonoClone);
    }

    
}
