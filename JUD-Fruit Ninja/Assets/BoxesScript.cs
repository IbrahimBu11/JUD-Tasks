using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesScript : MonoBehaviour
{
    public GameObject[] Splitboxes; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20)
            Destroy(gameObject);

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Cutter")
        {
            Fission();
            Destroy(gameObject);
        }
    }
    void Fission()
    {
        foreach(GameObject box in Splitboxes)
        {
            GameObject boxClone = Instantiate(box, transform.position, transform.rotation);

            //boxClone.GetComponent<Rigidbody>().AddForce(Random.Range(-,2))
        }
    }
}
