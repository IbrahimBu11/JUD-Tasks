using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsSpawnManager : MonoBehaviour
{
    public GameObject player;

    public List<GameObject> birdsList;
    public Dictionary<string, GameObject> birds;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBird", 2f, 2f);
        birds = new Dictionary<string, GameObject>();
        foreach (GameObject bird in birdsList)
        {
            birds.Add(bird.name, bird);
        }
        Debug.Log(birds.Count);
        foreach(KeyValuePair<string,GameObject> bird in birds)
        {
            Debug.Log(bird.Value);
        }
        
    }

    void SpawnBird()
    {
        Instantiate(birds["lb_blueJayHQ"],player.transform.forward + new Vector3(0,0,20),birds["lb_blueJayHQ"].transform.rotation);
        Debug.Log("works");
    }
}
