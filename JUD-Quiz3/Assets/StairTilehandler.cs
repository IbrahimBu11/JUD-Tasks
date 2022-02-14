using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StairTilehandler : MonoBehaviour
{

    private int redCount = 0;
    private int blueCount = 0;
    private int stairCount;
    
    private List<GameObject> stairTile = new List<GameObject>();
    List<GameObject> tiles;

    public TextMeshProUGUI text;


    public GameObject clone;
    public Transform head;
    float posYOffset = 0;



    private void Start()
    {
        for (int i = 0; i < 11; i++)
        {
            GameObject tileClone = Instantiate(clone, new Vector3(head.position.x, head.position.y + posYOffset, head.position.z), clone.transform.rotation);
            stairTile.Add(tileClone);
            posYOffset += 0.4f;
        }
        
    }

    //Check Win and declate winner when the count approaches to 10 for any player
    void CheckWin()
    {
        if(redCount > 10)
        {
            Debug.Log("Red Player Wins");
            text.SetText("Red Player Wins");
        }
        else if(blueCount > 10)
        {
            Debug.Log("Blue Player Wins");
            text.SetText("Blue Player Wins");
        }
    }
    public void AddTile()
    {

       // //tiles.Add(tile);
       // //tile.GetComponent<BoxCollider>().enabled = false;
       //// tiles = new List<GameObject>();
       //while(tilesBlue != null || tilesRed != null) { 
       //     int temp = 0;
       //     if (tilesBlue.Count > tilesBlue.Count)
       //     {
       //         temp = tilesBlue.Count - tilesRed.Count;
       //         foreach (GameObject tileClone in tilesRed)
       //         {
       //             tileClone.transform.SetParent(head);
       //             tileClone.transform.position = new Vector3(head.position.x, head.position.y + posYOffset, head.position.z);
       //             tileClone.transform.rotation = Quaternion.Euler(Vector3.zero);
       //             posYOffset += 0.4f;
       //         }
       //     }
       //     else
       //     {
       //         temp = tilesRed.Count - tilesBlue.Count;
       //         foreach (GameObject tileClone in tilesBlue)
       //         {
       //             tileClone.transform.SetParent(head);
       //             tileClone.transform.position = new Vector3(head.position.x, head.position.y + posYOffset, head.position.z);
       //             tileClone.transform.rotation = Quaternion.Euler(Vector3.zero);
       //             posYOffset += 0.4f;
       //         }
       //     }


       //     }
    }

    //Subtract the larger numb and add it to stairs
    void Balance()
    {
        if(redCount > blueCount)
        {
           stairCount =  redCount - blueCount;
            Populate(Color.red, redCount);
            Debug.Log("red works");
        }
        else if(blueCount < redCount)
        {
            stairCount = blueCount - redCount;
            Populate(Color.blue, blueCount);
            Debug.Log("blue works");
        }
        CheckWin();
    }
    //Populate the required number with color of the superior tile color population count
    void Populate(Color color, int count)
    {

        for (int i = 0; i < count; i++)
        {
            stairTile[i].GetComponent<MeshRenderer>().material.color = color;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("stsart");
            redCount = other.gameObject.GetComponent<PlayerTileHandler>().tiles.Count;
            Balance();
            other.gameObject.GetComponent<PlayerTileHandler>().Reset();
            Debug.Log("Red Trigger Works");
            
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            blueCount = other.gameObject.GetComponent<PlayerTileHandler>().tiles.Count;
            Balance();
            other.gameObject.GetComponent<PlayerTileHandler>().Reset();
            Debug.Log("blue Trigger Works");
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        redCount = other.gameObject.GetComponent<PlayerTileHandler>().tiles.Count;
    //        Balance();
    //    }
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        blueCount = other.gameObject.GetComponent<PlayerTileHandler>().tiles.Count;
    //        Balance();
    //    }

    //        if (other.gameObject.CompareTag("Player") )
    //    {
    //        //tiles = new List<GameObject>();
    //        tilesRed =  other.gameObject.GetComponent<PlayerTileHandler>().tiles;
    //        other.gameObject.GetComponent<PlayerTileHandler>().Reset();
    //        //GameObject clone
    //        Debug.Log(other.gameObject.GetComponent<PlayerTileHandler>().tiles.Count);
    //        Debug.Log(tilesRed.Count);


    //        clone = tilesRed[0];
    //        AddTile();
    //        Debug.Log("works");
    //    }
    //    if(other.gameObject.CompareTag("Enemy"))
    //    {
    //        tilesBlue = other.gameObject.GetComponent<PlayerTileHandler>().tiles;
    //        other.gameObject.GetComponent<PlayerTileHandler>().Reset();
    //        //GameObject clone
    //        Debug.Log(other.gameObject.GetComponent<PlayerTileHandler>().tiles.Count);
    //        Debug.Log(tilesBlue.Count);


    //        clone = tilesBlue[0];
    //        AddTile();
    //        Debug.Log("works");
    //    }
    //}
}
