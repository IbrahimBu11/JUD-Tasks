using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterController : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject bomb; 

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(move * Time.deltaTime);
        AlignToCenter(move);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBomb();
        }
        //rb.AddForce(move);
    }
    void AlignToCenter(Vector2 move)
    {
        //Returns position of the cell respective to world postion
        Vector3Int cell = tilemap.WorldToCell(transform.position);
        Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);
        if(move == Vector2.zero)
        transform.position = cellCenterPos;
    }
    void CreateBomb()
    {
        Instantiate(bomb, transform.position, transform.rotation);
    }
    
}
