using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private CharacterController controller;

    private float speed = 4.0f;
    private float rotationSpeed = 90.0f;
    Rigidbody rb;


    private void Start()
    {
        //controller = gameObject.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Get direction Input from Input System

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Move(move);      
    }


    //Move the character in the dirction of the move Vector based on Input
    void Move(Vector3 move)
    {
        transform.Translate(move * Time.deltaTime * speed);
        //transform.forward = rb.velocity;
        //gameObject.transform.forward = move;
       // transform.forward = rb.velocity;
        //If there is no input, Keep the face forward
        //if (move != Vector3.zero)
        //{
        //    Quaternion rotationDirection = Quaternion.LookRotation(move * Time.deltaTime);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationDirection,rotationSpeed* Time.deltaTime);
        //}
        
    }
}

