using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    public int numberOfEnemies;
    public int randomRangeSpawn;
    public int randomRangeEnemies;
    public float spawnTime; 
    public float  spawnTimeRND;
    public bool endOfTheWave;
    public int lvlFat;
    float exit_time;
    public Transform parent;
    private int sum;
    GameObject e;
    int num_waves = 9;
    int current_wave = 1;
    public TextAsset wavesTable;
    public UnityEngine.UI.Text WaveText;
    bool waveTextPrint = false;
    float timeTextPrint;

    void Start()
    {
        if (randomRangeEnemies < 1) randomRangeEnemies = 100;
        if (randomRangeSpawn < 1) randomRangeSpawn = 100;
        numberOfEnemies = Random.Range (numberOfEnemies - numberOfEnemies / randomRangeEnemies, numberOfEnemies + numberOfEnemies / randomRangeEnemies);
        spawnTimeRND = Random.Range (spawnTime - spawnTime / randomRangeSpawn, spawnTime + spawnTime / randomRangeSpawn);
        exit_time = Time.time + spawnTimeRND;
        WaveText.text = "Wave " + current_wave;
        waveTextPrint = true;
        timeTextPrint = Time.time + 5;
        SettingWave();
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
        if (endOfTheWave && current_wave < num_waves)
        {
            current_wave++;
            endOfTheWave = false;
            SettingWave();
            sum = 0;
            WaveText.text = "Wave " + current_wave;
            waveTextPrint = true;
            timeTextPrint = Time.time + 5;
        }
        if (waveTextPrint && Time.time > timeTextPrint)
        {
            WaveText.text = "";
            waveTextPrint = false;
        }
    }

    void SettingWave ()
    {

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
            e = Instantiate(enemy[Random.Range (0, enemy.Length)], transform.position, transform.rotation);
            e.transform.SetParent(parent);
            spawnTimeRND = Random.Range (spawnTime - spawnTime / randomRangeSpawn, spawnTime + spawnTime / randomRangeSpawn);
            exit_time = Time.time + spawnTimeRND;
        }
    }
}
