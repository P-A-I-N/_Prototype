using UnityEngine;
using System;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    int minTimeSpawn = 10;
    int maxTimeSpawn = 10;
    float spawnTimeRND;
    public bool endOfTheWave;
    float exit_time;
    public Transform parent;
    GameObject e;
    int num_waves = 24;
    int current_wave = 1;
    public TextAsset wavesTable;
    public UnityEngine.UI.Text WaveText;
    bool waveTextPrint = false;
    float timeTextPrint;
    float endWaveTime;
    bool waveIsActive = true;
    public GameObject waveScreen;
    public int firstEncounterWave;
    public WaveForm waveForm;
    public GameMap gm;
    bool fastStopEnable = true;
    float fastStopTimer;

    void Start()
    {
        waveScreen.SetActive(true);
        WaveText.text = "Wave " + current_wave;
        waveTextPrint = true;
        timeTextPrint = Time.time + 5; 
        string [] waves = wavesTable.text.Split ('\n');
        gm.wave = current_wave;
        gm.killedEnemies = 0;
        gm.totalEnemies = waveForm.numberOfEnemies[current_wave - 1];
        SettingWave(waves[0]);
    }
    void Update()
    {
        if (Time.time >= exit_time && !endOfTheWave && waveForm.sum < waveForm.numberOfEnemies[current_wave - 1] && waveIsActive)
        {
            CreateEnemy();
            waveForm.sum++;
        }
        if (endOfTheWave && current_wave < num_waves)
        {
            print("Ending " +gameObject.name);
            current_wave++;
            gm.wave = current_wave;
            if (gm.killedEnemies == gm.totalEnemies && gameObject.name == "Spawn 1")
            {
                gm.killedEnemies = 0;
                gm.totalEnemies = waveForm.numberOfEnemies[current_wave - 1];
            }
            else
            { 
                if (gameObject.name == "Spawn 1")
                {
                    gm.totalEnemies += waveForm.numberOfEnemies[current_wave - 1];
                }    
            }
            endOfTheWave = false;
            string[] waves = wavesTable.text.Split('\n');
            SettingWave( waves[current_wave - 1]) ;
            waveForm.sum = 0;
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
        if (gm.killedEnemies == gm.totalEnemies && fastStopEnable)
        {
            print (gameObject.name);
            //endWaveTime = Time.time;
            endOfTheWave = true;
            fastStopEnable = false;
            fastStopTimer = Time.time + 1f;
        }
        if (!fastStopEnable && Time.time > fastStopTimer)
        {
            fastStopEnable = true;
        }
    }

    void SettingWave (string wave)
    {
        string[] parametrs = wave.Split(' ');
        if (current_wave < firstEncounterWave)
        {
            endWaveTime = Time.time + Convert.ToInt32 (parametrs[27]);
            waveIsActive = false;
            return;
        }
        else waveIsActive = true; 
        minTimeSpawn = Convert.ToInt32 (parametrs[25]);
        maxTimeSpawn = Convert.ToInt32 (parametrs[26]);
        endWaveTime = Time.time + Convert.ToInt32 (parametrs[27]);
        spawnTimeRND = UnityEngine.Random.Range(minTimeSpawn, maxTimeSpawn);
        exit_time = Time.time + spawnTimeRND;
    }

    void CreateEnemy()
    {
        int tryIndex, enemyIndex;
        if (waveForm.sum < waveForm.numberOfEnemies [current_wave - 1])
        {
                while (true)
                {
                    tryIndex = UnityEngine.Random.Range(0, enemy.Length);
                    if (waveForm.enemiesCount[current_wave - 1, tryIndex] > 0)
                    {
                        enemyIndex = tryIndex;
                        waveForm.enemiesCount[current_wave - 1, enemyIndex]--;
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
        e.GetComponent<Enemy>().wave = current_wave;
        e.transform.SetParent(parent);
        spawnTimeRND = UnityEngine.Random.Range (minTimeSpawn, maxTimeSpawn);
        exit_time = Time.time + spawnTimeRND;
    }
}
