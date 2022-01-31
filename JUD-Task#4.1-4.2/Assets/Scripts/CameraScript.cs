using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public List<GameObject> Balls;

    private Bounds bounds;

    public Transform targetPlayer ;
    public Vector3 offset;
    public Vector3 velocity;
    public float smoothTime = .5f;

    // Start is called before the first frame update
    void Start()
    {
        Balls.AddRange(GameObject.FindGameObjectsWithTag("Balls"));
        //GetCenterPoint();
    }
    Vector3 GetCenterPoint() 
    {
        bounds = new Bounds();
        foreach (GameObject ball in Balls)
            bounds.Encapsulate(ball.transform.position);

        return bounds.center;

    }
    float GetGreatestDistance()
    {

    }
    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        //AddBounds();
        // transform.LookAt(centerPoint);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
    void Zoom()
    {

    }


    // Update is called once per frame
    void LateUpdate()
    {
        Move();
        Zoom();

    }
}
