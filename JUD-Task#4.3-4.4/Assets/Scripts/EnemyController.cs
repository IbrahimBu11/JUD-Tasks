using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //---------------------------------------------STATES------------------------------------------//
    public enum LaraiState {RangeAttack, Wrestle };
    public enum PositionState {isFollowing, isAtAppropriateDistance, immobolized}
    public LaraiState state = LaraiState.RangeAttack;
    public PositionState positionState = PositionState.isFollowing;

    //--------------------------------------------LISTS-------------------------------------------//
    public List<GameObject> Balls;
    public List<Transform> BallsTransform;


    //-----------------------------------VARIABLES FOR SHOOTING----------------------------------//
    //Bomb Shoot Position and Prefab
    public Transform shootPosition;
    public GameObject bomb;
    private float DelayBetweenShots = 2f;


    //-----------------------------------PLAYER MOVEMENT VARIABLES------------------------------//
    [SerializeField]
    private float Speed = 200f;

    private float minimumPlayerDistance = 2f;

    private Rigidbody rb;
    private Transform bestTarget = null;

    
    



    // Update is called once per frame

    void Start()
    {
        
        //Get Available Enemies In the Scene
        BallsInTheScene();
        GetClosestEnemy(BallsTransform);
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Shoot(DelayBetweenShots));
        
    }
    void BallsInTheScene()
    {
        Balls = new List<GameObject>();
        Balls.AddRange(GameObject.FindGameObjectsWithTag("Players"));
        BallsTransform = new List<Transform>();
        foreach(GameObject t in Balls)
        {
            BallsTransform.Add(t.transform);
        }
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Players"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 2f, ForceMode.Impulse);
        }
    }
    void Update()
    {
        BallsInTheScene();
        GetClosestEnemy(BallsTransform);
        DetermineStatenPosition();
        //Debug.Log(bestTarget.name);
        
        
        if (state == LaraiState.Wrestle) { 
            Move();          
        }
        if (state == LaraiState.RangeAttack)
        {
            Move();
        }
            
        LookRotation();

    }
    void DetermineStatenPosition()
    {
        if (transform.position.y < -5)
            Destroy(gameObject);

        if (Vector3.Distance(transform.position, bestTarget.position) < minimumPlayerDistance) 
        { 
            state = LaraiState.Wrestle;
            positionState = PositionState.isAtAppropriateDistance;
        }
        else 
        { 
            state = LaraiState.RangeAttack;
            positionState = PositionState.isFollowing; 
        }
    }
    IEnumerator Shoot(float delay)
    {
        while (true) 
        {
            if (state == LaraiState.RangeAttack && positionState != PositionState.isAtAppropriateDistance)
            {
                yield return new WaitForSeconds(delay);
                Instantiate(bomb, shootPosition.position, shootPosition.rotation);
            }
            else
                yield return null;
        }
    }
    
    void Move()
    {
        if (rb.velocity.magnitude < 5)
            rb.AddForce(transform.forward * Speed * Time.deltaTime);
    }
    void LookRotation()
    {
        Vector3 lookDirection = bestTarget.position - transform.position;
        transform.forward = lookDirection;
    }

    Transform GetClosestEnemy(List<Transform> enemies)
    {
        
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            if (transform.position != potentialTarget.transform.position) { 
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
            }
        }

        return bestTarget;
    }
}
