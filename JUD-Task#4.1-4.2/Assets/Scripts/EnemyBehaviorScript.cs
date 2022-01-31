using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorScript : MonoBehaviour
{


    // Start is called before the first frame update
    public List<GameObject> Balls;
    [SerializeField]
    private float Speed = 400f;

    private Rigidbody rb;

    public float PreviousShortestDistance = 999f;
    public GameObject lockedTarget;
    void Start()
    {
        Debug.Log(Mathf.InverseLerp(0, 100, 50));
        
       // rb = GetComponent<Rigidbody>();
      //  BallsInTheScene();
        //PreviousShortestDistance = Vector3.Distance(transform.position, Balls[1].transform.position);
       // foreach(GameObject ball in Balls)
      //  {
       //     Debug.Log(ball.name);
      //  }
     //   ShortestDistance();
       // lockedTarget = Balls[1];
    }

    // Update is called once per frame
    void Update()
    {
       // Move();
       // ShortestDistance();
       // LookRotation();
        
    }
    void BallsInTheScene()
    {
        Balls = new List<GameObject>();
        Balls.AddRange(GameObject.FindGameObjectsWithTag("Balls"));
    }
    void Move()
    {
        if (rb.velocity.magnitude < 10)
            rb.AddForce(transform.forward * Speed * Time.deltaTime, ForceMode.Acceleration);
    }
    void LookRotation()
    {
        transform.LookAt(lockedTarget.transform);
    }
    void ShortestDistance()
    {
        
        foreach(GameObject ball in Balls)
        {
           // if (gameObject.name == ball.name)
              //  continue;
            Debug.Log(Vector3.Distance(transform.position, ball.transform.position));
            if (Vector3.Distance(ball.transform.position, transform.position) < PreviousShortestDistance
                && Vector3.Distance(ball.transform.position,transform.position) != 0 )
            {
                lockedTarget = ball;
                PreviousShortestDistance = Vector3.Distance(transform.position, ball.transform.position);
                
                Debug.Log("worked");
            }
        }
    }
}
