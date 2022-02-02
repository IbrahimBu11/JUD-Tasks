using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    public SpawnState state = SpawnState.COUNTING;


    public GameObject enemy;

    public float timeBetweenWaves = 2f;
    public float countDown = 1f;
    public float searchCountdown = 1f;

    //public float searchCountdown = 1f; 

    public Transform[] spawnPositions;
    public List<GameObject> enemies = new List<GameObject>();
    private int waveIndex = 0;

    public GameObject[] Powerups;
    private float PowerUpSpawnDelay = 5f;
    private float TimeBetweetPowerUpSpwns = 3f;

    private void Start()
    {
        StartCoroutine(RunSpawner());
        InvokeRepeating("SpawnPowerUps", PowerUpSpawnDelay, timeBetweenWaves);
    }
    void SpawnPowerUps()
    {
        int random = Random.Range(0, Powerups.Length);
        Instantiate(Powerups[random], spawnPositions[Random.Range(0, spawnPositions.Length)].position, Powerups[random].transform.rotation);
    }

    // this replaces your Update method
    private IEnumerator RunSpawner()
    {
        
        yield return new WaitForSeconds(countDown);

      
        while (true)
        {
            state = SpawnState.SPAWNING;

            
            yield return SpawnWave();

            state = SpawnState.WAITING;

           
            yield return new WaitWhile(EnemyisAlive);

            state = SpawnState.COUNTING;
    
        
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
