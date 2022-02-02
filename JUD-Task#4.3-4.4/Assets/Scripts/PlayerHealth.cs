using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int StartingHealth;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = StartingHealth;
    }

    public void ReduceHealth(int damage)
    {
        health -= damage;
    }
    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
