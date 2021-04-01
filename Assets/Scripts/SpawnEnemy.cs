using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public int numberOfEnemies;
    public int randomRangeSpawn;
    public int randomRangeEnemies;
    public float spawnTime; 
    public float  spawnTimeRND;
    public bool endOfTheWave;
    float exit_time;
    public Transform parent;
    private int sum;
    GameObject e;
    int saldo_enemies_start, saldo_enemies_end;
    float saldo_spawn_start, saldo_spawn_end;

    void Start()
    {
        if (randomRangeEnemies < 1) randomRangeEnemies = 100;
        if (randomRangeSpawn < 1) randomRangeSpawn = 100;
        saldo_enemies_start = numberOfEnemies - numberOfEnemies / randomRangeEnemies;
        saldo_enemies_end = numberOfEnemies + numberOfEnemies / randomRangeEnemies;
        saldo_spawn_start = spawnTime - spawnTime / randomRangeSpawn;
        saldo_spawn_end = spawnTime + spawnTime / randomRangeSpawn;
        numberOfEnemies = Random.Range (saldo_enemies_start, saldo_enemies_end);
        spawnTimeRND = Random.Range (saldo_spawn_start, saldo_spawn_end);
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
            spawnTimeRND = Random.Range (saldo_spawn_start, saldo_spawn_end);
            exit_time = Time.time + spawnTimeRND;
        }
    }
}
