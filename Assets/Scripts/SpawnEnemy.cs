using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public int numberOfEnemies;
    private int sum;
    public float spawnTime;
    public bool endOfTheWave;
    GameObject e;
    public Transform parent;

    void Start()
    {
        InvokeRepeating("CreateEnemy", spawnTime, spawnTime);
        InvokeRepeating("summ", spawnTime, spawnTime);
    }
    void Update()
    {
        if(sum == numberOfEnemies)
        {
            endOfTheWave = true;
        }
    }


    void summ()
    {
        if (sum < numberOfEnemies)
        {
            sum++;
        }
    }

    void CreateEnemy()
    {
        if (sum < numberOfEnemies)
        {
            e = Instantiate(enemy, transform.position, transform.rotation);
            e.transform.SetParent(parent);
        }
    }
}
