using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject cutter;
    void Update()
    {
        //Vector3 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //pos.z = -2f;
        //cutter.transform.position = pos; 
            
            
        if (Input.GetKey(KeyCode.Mouse0))
        {
            EnableCutter();
            Shoot();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            DisableCutter();
        }
    }

    void Shoot()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 pos = hit.point;
            pos.z = -7.29f;
            cutter.transform.position = pos;
        }
    }

    void EnableCutter()
    {
        cutter.GetComponent<BoxCollider>().enabled = true;
    }
    void DisableCutter()
    {
        cutter.GetComponent<BoxCollider>().enabled = false;
    }
}
