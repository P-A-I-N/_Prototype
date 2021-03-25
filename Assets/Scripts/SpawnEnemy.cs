using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public int numberOfEnemies;
    private int sum;
    public float spawnTime; 
    public float  spawnTimeRND;
    public bool endOfTheWave;
    float exit_time;
    GameObject e;
    public Transform parent;
    public int randomRangeSpawn;
    public int randomRangeEnemies;

    void Start()
    {
        if (randomRangeEnemies < 1) randomRangeEnemies = 100;
        if (randomRangeSpawn < 1) randomRangeSpawn = 100;
        numberOfEnemies = Random.Range (numberOfEnemies - numberOfEnemies / randomRangeEnemies, numberOfEnemies + numberOfEnemies / randomRangeEnemies);
        spawnTimeRND = Random.Range (spawnTime - spawnTime / randomRangeSpawn, spawnTime + spawnTime / randomRangeSpawn);
        exit_time = Time.time + spawnTimeRND;
        //InvokeRepeating("CreateEnemy", spawnTime, spawnTime);
        //InvokeRepeating("summ", spawnTime, spawnTime);
    }
    void Update()
    {
        if (Time.time >= exit_time && !endOfTheWave)
        {
            CreateEnemy();
            summ();
        }
        //if(sum == numberOfEnemies)
        //{
        //    endOfTheWave = true;
        //}
    }


    void summ()
    {
        if (sum < numberOfEnemies)
        {
            sum++;
        }
        else endOfTheWave = true;
    }

    void CreateEnemy()
    {
        if (sum < numberOfEnemies)
        {
            e = Instantiate(enemy, transform.position, transform.rotation);
            e.transform.SetParent(parent);
            spawnTimeRND = Random.Range (spawnTime - spawnTime / randomRangeSpawn, spawnTime + spawnTime / randomRangeSpawn);
            exit_time = Time.time + spawnTimeRND;
        }
    }
}
