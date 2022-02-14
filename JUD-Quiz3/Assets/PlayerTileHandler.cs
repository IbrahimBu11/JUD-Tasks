using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileHandler : MonoBehaviour
{
    public List<GameObject> tiles;
    public Transform head;
    float posYOffset = 0;

    public string color ;

    void Start()
    {
        tiles = new List<GameObject>();
    }
    public void AddTile(GameObject tile)
    {

        tiles.Add(tile);
        tile.GetComponent<BoxCollider>().enabled = false;
        posYOffset = 0;
        foreach (GameObject tileClone in tiles)
        {           
            tileClone.transform.position = new Vector3(head.position.x, head.position.y + posYOffset, head.position.z);
            tileClone.transform.rotation = Quaternion.Euler(Vector3.zero);
            posYOffset += 0.4f;
        }
    }
    void Update()
    {
        //Debug.Log(tiles.Count);    
    }
    public void Reset()
    {
        tiles = new List<GameObject>();
    }
}
