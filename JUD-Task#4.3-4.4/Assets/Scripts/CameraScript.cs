using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 offset;

    public Bounds bound;
    public List<GameObject> players;
    void Start()
    {
        keepCheckingBounds();
        
    }
    void LateUpdate()
    {
        keepCheckingBounds();
        transform.LookAt(bound.center);
        transform.position = bound.center + offset;

    }
    void keepCheckingBounds()
    {
        players = new List<GameObject>();
        players.AddRange(GameObject.FindGameObjectsWithTag("Players"));
        if(players != null) 
        { 
        foreach (GameObject players in players)
            bound.Encapsulate(players.transform.position);
        }
    }
}
