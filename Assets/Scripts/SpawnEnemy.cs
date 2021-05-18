using UnityEngine;
using System;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    int numberOfEnemies;
    int minTimeSpawn = 10;
    int maxTimeSpawn = 10;
    float spawnTimeRND;
    public bool endOfTheWave;
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
    //float[] timeWaves = new float[26] {100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
    float endWaveTime;
    bool waveIsActive = true;
    public GameObject waveScreen;
    int[] enemiesCount = new int[5];
    public int firstEncounterWave;

    void Start()
    {
        waveScreen.SetActive(true);
        WaveText.text = "Wave " + current_wave;
        waveTextPrint = true;
        timeTextPrint = Time.time + 5; 
        //endWaveTime = Time.time + timeWaves[0];
        string [] waves = wavesTable.text.Split ('\n');
        SettingWave(waves[0]);
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
            //endWaveTime = Time.time + timeWaves[current_wave];
            current_wave++;
            endOfTheWave = false;
            string[] waves = wavesTable.text.Split('\n');
            SettingWave( waves[current_wave - 1]) ;
            sum = 0;
            WaveText.text = "Wave " + current_wave;
            waveTextPrint = true;
            timeTextPrint = Time.time + 5;
            waveScreen.SetActive(true);
        }
        if (waveTextPrint && Time.time > timeTextPrint)
        {
            waveScreen.SetActive(false);
            waveTextPrint = false;
        }
        if (Time.time > endWaveTime)
        {
            endOfTheWave = true;
        }
    }

    void SettingWave (string wave)
    {
        string[] parametrs = wave.Split(' ');
        if (current_wave < firstEncounterWave)
        {
            endWaveTime = Time.time + Convert.ToInt32 (parametrs[8]);
            waveIsActive = false;
            return;
        }
        else waveIsActive = true; 
        enemiesCount[0] = Convert.ToInt32 (parametrs[0]);
        enemiesCount[1] = Convert.ToInt32 (parametrs[1]);
        enemiesCount[2] = Convert.ToInt32 (parametrs[2]);
        enemiesCount[3] = Convert.ToInt32 (parametrs[3]);
        enemiesCount[4] = Convert.ToInt32 (parametrs[4]);
        numberOfEnemies = Convert.ToInt32 (parametrs[5]);
        minTimeSpawn = Convert.ToInt32 (parametrs[6]);
        maxTimeSpawn = Convert.ToInt32 (parametrs[7]);
        endWaveTime = Time.time + Convert.ToInt32 (parametrs[8]);
    }

    void CreateEnemy()
    {
        int tryIndex, enemyIndex;
        if (sum < numberOfEnemies)
        {
            //print(enemiesCount[0] + enemiesCount[1] + enemiesCount[2] + enemiesCount[3] + enemiesCount[4]);
            if (enemiesCount[0] + enemiesCount[1] + enemiesCount[2] + enemiesCount[3] + enemiesCount[4] > 0)
            {
                while (true)
                {
                    tryIndex = UnityEngine.Random.Range(0, enemy.Length);
                    if (enemiesCount[tryIndex] > 0)
                    {
                        enemyIndex = tryIndex;
                        enemiesCount[enemyIndex]--;
                        break;
                    }
                }
            }
            else
            {
                waveIsActive = false;
                return; 
            }
            e = Instantiate(enemy[enemyIndex], transform.position, transform.rotation);
            e.transform.SetParent(parent);
            spawnTimeRND = UnityEngine.Random.Range (minTimeSpawn, maxTimeSpawn);
            exit_time = Time.time + spawnTimeRND;
        }
    }
}
