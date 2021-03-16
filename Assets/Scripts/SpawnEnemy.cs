using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    //public GameObject boos;
    public int sum;
    public float spawnTime;

    void Start()
    {
        InvokeRepeating("CreateEnemy", spawnTime, spawnTime);
        InvokeRepeating("summ", spawnTime, spawnTime);
        //InvokeRepeating("CrateBoss", 50f, 50f);
    }

    
    void summ()
    {
        if (sum < 10)
        {
            sum++;
        }
    }

    void CreateEnemy()
    {
        if (sum < 10)
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }
    }

    //void CrateBoss()
    //{
    //    if (sum >= 10 && sum < 11)
    //    {
    //        sum++;
    //        Instantiate(boos, transform.position, transform.rotation);
    //    }
    //}
}
