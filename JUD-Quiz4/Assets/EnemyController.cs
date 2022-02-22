using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyController : MonoBehaviour
{
    public Tilemap navigateable ;
    public Tilemap destructables;
    public List<Vector3> availablePlaces;


    private Vector2 destination;
    private bool isMoving;

    //public TileBase[] allTiles;
    // Start is called before the first frame update
    void Start()
    {
        //GetAllAvailableSpaces();
        foreach(Vector3 places in availablePlaces)
        {
            Debug.Log(places);
        }
        //BoundsInt size = navigateable.cellBounds;
        //allTiles = navigateable.GetTilesBlock(size);
        //for (int x = 0; x < size.size.x; x++)
        //{
        //    for (int y = 0; y < size.size.y; y++)
        //    {
        //        TileBase tile = allTiles[x + y * size.size.x];
        //        if (tile != null)
        //        {
        //            Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
        //        }
        //        else
        //        {
        //            Debug.Log("x:" + x + " y:" + y + " tile: (null)");
        //        }
        //    }
        //}

    }
    //void  GetAllAvailableSpaces()
    //{
    //   // bool isTrue = true;
    //    availablePlaces = new List<Vector3>();

    //    for (int n = navigateable.cellBounds.xMin; n < navigateable.cellBounds.xMax; n++)
    //    {
    //        for (int p = navigateable.cellBounds.yMin; p < navigateable.cellBounds.yMax; p++)
    //        {
    //            Vector3Int localPlace = (new Vector3Int(n, p, (int)navigateable.transform.position.y));
    //            Vector3 place = navigateable.CellToWorld(localPlace);
    //            if (navigateable.HasTile(localPlace))
    //            {
    //                if(!destructables.HasTile(localPlace))
    //                availablePlaces.Add(place);
    //                //isTrue = true;
    //            }
    //            else
    //            {
    //                //isTrue = false;
    //            }
    //        }
    //    }
    //    //return isTrue;
    //}
   
    void MoveRandom()
    {
        Vector3Int cell = navigateable.WorldToCell(transform.position );
        Vector3 cellCenterPos = navigateable.GetCellCenterWorld(cell);
        Vector2 cell2d = new Vector2(cellCenterPos.x, cellCenterPos.y) + new Vector2(1, 0);
        if(Vector2.Distance(transform.position, cell2d) > 1f)
        transform.Translate(cell2d * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        // MoveRandom();

        //if (!isMoving) 
        //{ 
        //destination = PickRandomTile();
        //}
        //if (Vector2.Distance(transform.position, destination) > 0.1f)
        //{
        //    isMoving = false;
        //    transform.Translate(destination * Time.deltaTime);

        //}
        AlignToCenter();
    }
    void AlignToCenter()
    {
        //Returns position of the cell respective to world postion
        Vector3Int cell = navigateable.WorldToCell(transform.position);
        Vector3 cellCenterPos = navigateable.GetCellCenterWorld(cell);       
        transform.position = cellCenterPos;
    }
    Vector2 PickRandomTile()
    {
        isMoving = true;
        int random = Random.Range(0, availablePlaces.Count);
        Vector2 pos = new Vector2(availablePlaces[random].x, availablePlaces[random].y);
        return pos;
        

    }
}
