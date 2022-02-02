using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 offset;

    public Bounds bound;
    public List<GameObject> players;

    private float maximumZoom = 40f;
    private float minimumZoom = 10f;
    private float ZoomLimiter = 50f;

    public Camera cam;


    void Start()
    {
        keepCheckingBounds();
        cam = GetComponent<Camera>();

        
    }
    void LateUpdate()
    {
        keepCheckingBounds();
        Move();
        Zoom();


    }
    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        transform.LookAt(centerPoint);
        transform.position = centerPoint + offset;
    }
    void Zoom()
    {
        float newZoom = Mathf.Lerp(minimumZoom, maximumZoom, GetMaximumDistance() / ZoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }
    Vector3 GetCenterPoint()
    {
        players = new List<GameObject>();
        players.AddRange(GameObject.FindGameObjectsWithTag("Players"));
        if (players != null)
        {
            foreach (GameObject players in players)
                bound.Encapsulate(players.transform.position);
        }
        return bound.center;
    }
    float GetMaximumDistance()
    {
        players = new List<GameObject>();
        players.AddRange(GameObject.FindGameObjectsWithTag("Players"));
        if (players != null)
        {
            foreach (GameObject players in players)
                bound.Encapsulate(players.transform.position);
        }
        return bound.size.x;
    }
    void keepCheckingBounds()
    {
        
    }
}
