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

    //Add tiles in the and populate gameobjectrs on top of the player
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

    //Collision and for soome reaso its not working
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<PlayerTileHandler>().tiles.Count > tiles.Count)
            {
                collision.gameObject.GetComponent<PlayerTileHandler>().Reset();
            }
        }
        Debug.Log("works");
    }

    void ControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            if (hit.gameObject.GetComponent<PlayerTileHandler>().tiles.Count > tiles.Count)
            {
                hit.gameObject.GetComponent<PlayerTileHandler>().Reset();
            }
        }
        Debug.Log("works");
    }
    void Update()
    {
        //Debug.Log(tiles.Count);    
    }

    //resets the list to a new list and destroys the game object childs
    public void Reset()
    {
        tiles = new List<GameObject>();
        int childs = transform.childCount;
        foreach(Transform child in transform)
        {
            if(child.name != "Head")
            {
                Destroy(child.gameObject);
            }
        }
    }
}
