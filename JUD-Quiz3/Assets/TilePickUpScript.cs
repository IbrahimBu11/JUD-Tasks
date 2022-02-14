using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePickUpScript : MonoBehaviour
{
    public GameObject TileSpawner;

    public Vector3 initialPos;

    public int row;
    public int column;
    public string color;


    void Start()
    {
        TileSpawner = GameObject.Find("TileSpawner");
        initialPos = transform.position;    
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))//|| collision.gameObject.CompareTag("Enemy"))
        {
            if(color == other.gameObject.GetComponent<PlayerTileHandler>().color) { 
            TileSpawner.GetComponent<TileSpawnerScript>().StartCoroutine("WaitandRespawn", gameObject);
            gameObject.transform.SetParent(other.gameObject.transform);
            other.gameObject.GetComponent<PlayerTileHandler>().AddTile(gameObject);
            }
        }
    }
}
