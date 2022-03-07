using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private bool canPickUp;
    private float PickupTimer = 0f;

    public CharacterController controller;
    public Animator anim;

    private bool isPicking;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PickupLogic();

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Move(move);
        Animate(move);

        if (canPickUp && Input.GetKey(KeyCode.F))
            isPicking = true;


        

    }
    void PickupLogic()
    {
        if (isPicking)
            PickupTimer += Time.deltaTime;
        else
            PickupTimer = 0f;

        if(PickupTimer > 6f)
        {
            isPicking = false;
            //has Collected Stuff
        }
    }
    void Move(Vector3 direction)
    {
        controller.Move(direction * Time.deltaTime );
        if (direction != Vector3.zero)
        {
            transform.forward = Vector3.RotateTowards(transform.rotation.eulerAngles, direction,2f,2f);
            isPicking = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FruitArea")
        {
            canPickUp = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FruitArea")
        {
            canPickUp = false;
        }
    }
    IEnumerator WaitFortime(GameObject fruit)
    {
        isPicking = true;
        anim.SetBool("isPicking", true);
        yield return new WaitForSeconds(4);
        isPicking = false;
        anim.SetBool("isPicking", false);
    }
    void Animate(Vector3 input)
    {
        anim.SetBool("isPicking", isPicking);

        if (input != Vector3.zero)
        {
            anim.SetBool("isWalking", true);
        }
        else
            anim.SetBool("isWalking", false);
    }
}
