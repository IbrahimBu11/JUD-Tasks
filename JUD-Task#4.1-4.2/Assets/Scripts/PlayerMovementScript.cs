using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private float horizontal, vertical;
    [SerializeField]
    private float Speed = 2f;
    [SerializeField]
    private float rotationSpeed = 5;
    private Rigidbody rb;

    private Vector3 LookDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Move();
        LookRotation();
    }
    void Move()
    {
        //transform.Translate(((Vector3.forward * vertical) + (Vector3.right * horizontal)) * Speed * Time.deltaTime);
        if(rb.velocity.magnitude < 10)
        rb.AddForce(((Vector3.forward * vertical) + (Vector3.right * horizontal)) * Speed * Time.deltaTime, ForceMode.Acceleration);
        //if (horizontal == 0 && vertical == 0)
        //    rb.velocity -= Vector3.one * Time.deltaTime;

    }
    void LookRotation()
    {
        LookDirection = (transform.position + rb.velocity);
        if (LookDirection != Vector3.zero)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookDirection), Time.deltaTime * rotationSpeed);
            transform.LookAt(LookDirection);
        }
        else
            transform.LookAt(transform.forward);
    }
}
