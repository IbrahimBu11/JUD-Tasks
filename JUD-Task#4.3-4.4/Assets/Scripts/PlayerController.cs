using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    public Rigidbody rb;
     
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float RotateSpeed = 20.0f;
    private float jumpHeight = 5.0f;
    private float gravityValue = -9.81f;

    public GameObject bomb;
    public Transform shootPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        // controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
        movementDirection.Normalize();



        Move(movementDirection);
        Rotation(movementDirection);
        Jump();
        Shoot();
        
        
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(bomb, shootPosition.position, shootPosition.rotation);
        }
    }
    void Rotation(Vector3 moveDirection)
    {
       // transform.rotation *= Quaternion.Euler(0f, horizontal * Time.deltaTime * RotateSpeed, 0f);
       // transform.rotation = Quaternion.LookRotation(rb.velocity);

        if (moveDirection != Vector3.zero)
        {
            //transform.forward = Vector3.Lerp(transform.position,moveDirection,Time.deltaTime * RotateSpeed );
            transform.forward = moveDirection;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Players"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 10f, ForceMode.Impulse);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            groundedPlayer = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            groundedPlayer = false;
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            groundedPlayer = false;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
    }

    void Move(Vector3 moveDirection)
    {
        //controller.Move((Vector3.forward * horizontal) + (Vector3.right * vertical) * Time.deltaTime);
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // controller.Move(move * Time.deltaTime * playerSpeed);

        transform.Translate(moveDirection * playerSpeed * Time.deltaTime, Space.World);
        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

    }
}
