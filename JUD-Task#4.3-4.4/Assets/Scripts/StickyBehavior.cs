using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBehavior : BombBehaviorScript
{
    Vector3 stickyPoint;

    private void OnCollisionEnter(Collision collision)
    {
       // if(bombState == BombState.IsThrown)
        if (collision.gameObject.CompareTag("Players"))
        {
            transform.parent = collision.transform;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            
            Debug.Log("hasworked");
            Debug.Log(transform.parent.gameObject.name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
