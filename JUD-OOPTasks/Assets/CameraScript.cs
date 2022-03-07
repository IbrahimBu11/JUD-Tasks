using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector3 direction = Vector3.Lerp(transform.position, target.transform.position, 0.5f);
        transform.LookAt(target.GetChild(2).transform);
        transform.position = target.transform.position - offset;




    }
}
