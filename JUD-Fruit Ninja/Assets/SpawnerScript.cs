using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] boxes;



    public void Start()
    {
        StartGame(1);
    }
    // Start is called before the first frame update
    void StartGame(int SpawnRate)
    {
        InvokeRepeating("SpawnBox", 1f, SpawnRate);
    }

    void SpawnBox()
    {
        GameObject box = Instantiate(boxes[Random.Range(0, 2)], transform.position, boxes[0].transform.rotation);

        box.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-4,4), Random.Range(10, 20), 0), ForceMode.Impulse);
        //box.GetComponent<Rigidbody>().AddForce(new Vector3(0, Random.Range(15, 25), 0), ForceMode.Impulse);
        box.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-8, 8), 0, 0), ForceMode.Impulse);
    }
    
}
