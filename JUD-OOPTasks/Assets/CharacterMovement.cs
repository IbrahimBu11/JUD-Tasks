using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{


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
     Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Move(move);
        Animate(move);


    }
    void Move(Vector3 direction)
    {
        controller.Move(direction * Time.deltaTime );
        if(direction != Vector3.zero)
        transform.forward  =  direction;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Cube")
        {
            StartCoroutine(WaitFortime(other.gameObject));
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
        if (input != Vector3.zero)
        {
            anim.SetBool("isWalking", true);
           // anim.SetBool("isPicking", false);
        }
        else
            anim.SetBool("isWalking", false);

        //if (isPicking)
        //    anim.SetBool("isPicking", true);
        //else if (!isPicking)
        //    anim.SetBool("isPicking", false);

    }
}
