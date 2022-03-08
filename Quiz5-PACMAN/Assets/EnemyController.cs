using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool changingDir = false;
    private Vector3 direction = Vector3.right;

    private void Update()
    {
        Move(direction);
    }
    void Move(Vector3 direction)
    {

        transform.Translate(direction * Time.deltaTime);
        CastingRay(Vector3.right);
        CastingRay(Vector3.left);
    }

    void CastingRay(Vector3 direction)
    {
       
        RaycastHit hit;


        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, 1))
        {
            
            if(hit.collider.GetComponent<monoCellSimple>().status == Status.wall)
            {
                ChangeDirection();
            }
        }
      
            
        
    }
    void ChangeDirection()
    {
        direction = -direction;    
    }
    IEnumerator waitForTime(float time)
    {
        yield return new WaitForSeconds(time);
        changingDir = false;

    }
}
