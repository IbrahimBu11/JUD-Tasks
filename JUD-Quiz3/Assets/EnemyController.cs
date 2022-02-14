using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public CharacterController controller;
    public NavMeshAgent nav;


    public GameObject tilespawner;
    public Vector3 randomPos;
    public Vector3 currentDestination;

    public Transform player;
    public Transform stairs;

    public bool movingToDestination = false;
    private void Update()
    {
        currentDestination = randomPos;

        if (Vector3.Distance(transform.position,player.position) < 3 )
        {
            nav.SetDestination(player.position);
            
            movingToDestination = false;

        }
        else if(!movingToDestination) 
        {
            MoveRandom();
            
        }
        if(Vector3.Distance(transform.position,randomPos) < 2f)
        {
            Debug.Log(Vector3.Distance(transform.position, randomPos));
            movingToDestination = false;
        }
        if(GetComponent<PlayerTileHandler>().tiles.Count > 4)
        {
            nav.SetDestination(stairs.position);

        }
    }
 
    //void GetNearestTile()
    //{
    //    List<GameObject> list = new List<GameObject>();
    //    float nearestTile = 999f;
    //    for (int i = 0; i < tilespawner.GetComponent<TileSpawnerScript>().tiles.Count; i++)
    //    {
    //        for (int j = 0; j < tilespawner.GetComponent<TileSpawnerScript>().tiles[0].Count; j++)
    //        {
    //            if()
    //        }
    //    }
    //}
    void MoveToFinish()
    {
        nav.SetDestination(stairs.transform.position);
    }
    void MoveRandom()
    {
        nav.SetDestination(PickRandomLoc());
        movingToDestination = true;
    }
    Vector3 PickRandomLoc()
    {
        randomPos = new Vector3(Random.Range(-22, 22), 0, Random.Range(-22, 22));
        
        return randomPos; 
    }
}
