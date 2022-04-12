using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveForm : MonoBehaviour
{
    public TextAsset wavesTable;
    public int [,] enemiesCount = new int [50,25];
    public int [] numberOfEnemies = new int [50];
    public int[] minTimeSpawn = new int[50];
    public int[] maxTimeSpawn = new int[50];
    public int[] timeWave = new int[50];
    public int sum = 0;
    // Start is called before the first frame update
    void Start()
    {
        string[] waves = wavesTable.text.Split ('\n');
        for (int i = 0; i < 50; i++)
        {
            string[] parametrs = waves[i].Split (' ');
            for (int j = 0; j < 25; j++)
            {
                enemiesCount[i, j] = Convert.ToInt32(parametrs[j]);
                numberOfEnemies[i] += Convert.ToInt32(parametrs[j]);
            }
            minTimeSpawn[i] = Convert.ToInt32(parametrs[25]);
            maxTimeSpawn[i] = Convert.ToInt32(parametrs[26]);
            timeWave[i] = Convert.ToInt32(parametrs[27]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
