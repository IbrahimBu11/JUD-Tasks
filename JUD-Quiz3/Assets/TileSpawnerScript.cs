using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnerScript : MonoBehaviour
{
    public GameObject[] TilePrefab;

    public GameObject plane;

    public Vector3 offset = new Vector3(-20, 0, -10);

    private int rowLength;
    private int columnLength;

    private int rowGap = 8;
    private int columnGap = 9;

    public List<List<GameObject>> tiles;

    void Start()
    {
        //Get row/column length by the ratio  of floor scale to the gap

        rowLength = (int) plane.transform.localScale.x/rowGap;
        columnLength =  (int)plane.transform.localScale.z / columnGap;

        Debug.Log(plane.transform.localScale.x + " " + plane.transform.localScale.z);
        Debug.Log(rowLength + "  " + columnLength);
        SpawnTileLoop();
    }
    IEnumerator WaitandRespawn(GameObject tile)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(TilePrefab[Random.Range(0,2)], tile.GetComponent<TilePickUpScript>().initialPos, Quaternion.identity);

    }

    void SpawnTileLoop()
    {

        tiles = new List<List<GameObject>>();
        //Vector3 Tileposition = new Vector3();
        for (int i = 0; i < rowLength; i++)
        {
            tiles.Add(new List<GameObject>());
            for (int j = 0; j < columnLength; j++)
            {
                SpawnTiles(TilePrefab[Random.Range(0,2)], i, j);
            }
        }
    }

    void SpawnTiles(GameObject tile, int row, int column)
    {
        GameObject tileClone = Instantiate(tile, tile.transform.position, tile.transform.rotation);

        tileClone.GetComponent<TilePickUpScript>().row = row;
        tileClone.GetComponent<TilePickUpScript>().column = column;
        float posx = rowGap * row + offset.x;
        float posz = rowLength * column + offset.z;
        tileClone.transform.position = new Vector3(posx, tileClone.transform.position.y, posz);
        tiles[row].Add(tileClone); 
    }

}
