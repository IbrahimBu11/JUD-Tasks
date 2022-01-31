using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    public SpawnState state = SpawnState.COUNTING;


    public GameObject enemy;

    public float timeBetweenWaves = 5f;
    public float countDown = 2f;
    public float searchCountdown = 1f;

    //public float searchCountdown = 1f; 

    public Transform[] spawnPositions;
    public List<GameObject> enemies = new List<GameObject>();
    private int waveIndex = 0;

    private void Start()
    {
        StartCoroutine(RunSpawner());
    }

    // this replaces your Update method
    private IEnumerator RunSpawner()
    {
        // first time wait 2 seconds
        yield return new WaitForSeconds(countDown);

        // run this routine infinite
        while (true)
        {
            state = SpawnState.SPAWNING;

            // do the spawning and at the same time wait until it's finished
            yield return SpawnWave();

            state = SpawnState.WAITING;

            // wait until all enemies died (are destroyed)
            yield return new WaitWhile(EnemyisAlive);

            state = SpawnState.COUNTING;
    
        // wait 5 seconds
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    bool EnemyisAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Players").Length == 1)
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        
        enemies.Add(Instantiate(enemy, spawnPositions[Random.Range(0,spawnPositions.Length)].position, enemy.transform.rotation));
    }
}
