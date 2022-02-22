using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombScript : MonoBehaviour
{
    public int explosionRadius = 1;
    public float countdown = 2f;
    public Tilemap tilemap;

    public GameObject tile;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GameObject.Find("DestructableBoxes").GetComponent<Tilemap>();
        tile = GameObject.Find("Grid");
        AlignToCenter();
        StartCoroutine(WaitAndExplode());
    }
    //Align the bomb to center of the cell where it is instantiated
    void AlignToCenter()
    {
        //Returns position of the cell respective to world postion
        Vector3Int cell = tilemap.WorldToCell(transform.position);
        Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);
        transform.position = cellCenterPos;
    }


    IEnumerator WaitAndExplode()
    {
        yield return new WaitForSeconds(countdown);
        Explode();
        Destroy(gameObject);
    }
    void Explode()
    {
        tile.GetComponent<TilemapManager>().Explode(transform.position, explosionRadius);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
