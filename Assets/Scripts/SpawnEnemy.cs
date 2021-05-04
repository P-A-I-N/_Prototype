using UnityEngine;
using System;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    int numberOfEnemies;
    //public int randomRangeEnemies;
    int minTimeSpawn = 10;
    int maxTimeSpawn = 10;
    //float spawnTime; 
    float spawnTimeRND;
    public bool endOfTheWave;
    //int lvlFat;
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
    float[] timeWaves = new float[26] {100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
    float endWaveTime;
    bool waveIsActive = true;

    void Start()
    {
        //if (randomRangeEnemies < 1) randomRangeEnemies = 100;
        //numberOfEnemies = UnityEngine.Random.Range (numberOfEnemies - numberOfEnemies / randomRangeEnemies, numberOfEnemies + numberOfEnemies / randomRangeEnemies);
        //spawnTimeRND = UnityEngine.Random.Range (minTimeSpawn, maxTimeSpawn);
        //exit_time = Time.time + spawnTimeRND;
        WaveText.text = "Wave " + current_wave;
        waveTextPrint = true;
        timeTextPrint = Time.time + 5; 
        endWaveTime = Time.time + timeWaves[0];
        string [] waves = wavesTable.text.Split ('\n');
        SettingWave(waves [0]);
        //InvokeRepeating("CreateEnemy", spawnTime, spawnTime);
        //InvokeRepeating("summ", spawnTime, spawnTime);
    }
    void Update()
    {
        if (Time.time >= exit_time && !endOfTheWave && sum < numberOfEnemies && waveIsActive)
        {
            CreateEnemy();
            sum++;
        }
        if (endOfTheWave && current_wave < num_waves)
        {
            endWaveTime = Time.time + timeWaves[current_wave];
            current_wave++;
            endOfTheWave = false;
            string[] waves = wavesTable.text.Split('\n');
            SettingWave( waves[current_wave - 1]) ;
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
        if (Time.time > endWaveTime)
        {
            endOfTheWave = true;
        }
    }

    void SettingWave (string wave)
    {
        if (wave == "n")
        {
            waveIsActive = false;
            return;
        }
        else waveIsActive = true;
        string[] parametrs = wave.Split(' ');
        numberOfEnemies = Convert.ToInt32 (parametrs[0]);
        minTimeSpawn = Convert.ToInt32 (parametrs[1]);
        maxTimeSpawn = Convert.ToInt32 (parametrs[2]);
    }

    void CreateEnemy()
    {
        if (sum < numberOfEnemies)
        {
            e = Instantiate(enemy[UnityEngine.Random.Range (0, enemy.Length)], transform.position, transform.rotation);
            e.transform.SetParent(parent);
            spawnTimeRND = UnityEngine.Random.Range (minTimeSpawn, maxTimeSpawn);
            exit_time = Time.time + spawnTimeRND;
        }
    }
}
