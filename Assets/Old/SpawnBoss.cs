using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject boss;
    public GameObject[] spawn;
    public float bossDelay;
    private bool[] createBoss;
    private bool spawnBoss;
    public void Start()
    {
        createBoss = new bool[5];
    }

    public void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            createBoss[i] = spawn[i].GetComponent<SpawnEnemy>().endOfTheWave;

        }
        if (createBoss[0] && createBoss[1] && createBoss[2] && createBoss[3] && createBoss[4] && !spawnBoss)
        {
            Invoke("spawnTime", bossDelay);
            spawnBoss = !spawnBoss;
        }
    }

    void spawnTime()
    {
        Instantiate(boss, transform.position, transform.rotation);
    }
}
