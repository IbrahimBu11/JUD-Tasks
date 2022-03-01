using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombScript : MonoBehaviour
{
    public int explosionRadius = 3;

    

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
        //CastingRay(Vector3.right, explosionRadius);
        CastingRay(Vector3.up, explosionRadius);
        CastingRay(Vector3.down, explosionRadius);
        CastingRay(Vector3.right, explosionRadius);
        CastingRay(Vector3.left, explosionRadius);
        Destroy(gameObject);
    }
    void Explode()
    {
        tile.GetComponent<TilemapManager>().Explode(transform.position, explosionRadius);
        
    }
    void CastingRay(Vector3 direction, float range)
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, range);
        Debug.DrawRay(transform.position, direction, Color.blue, 2f);
        if (hit)
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.gameObject.name.StartsWith("Square")){
                Debug.Log("has hit square");
                Destroy(hit.collider.gameObject);
                //Debug.Log("has hit square");
            }
            if(hit.collider.gameObject.name == "BombMan")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Lives--;
            }
        }
        //    if (//hit.collider.gameObject.name == "Square")
        //    {
        //       // Destroy(hit.collider.gameObject);
        //    }
        //}
        // Update is called once per frame
    }
    void Update()
    {
        
    }
}
