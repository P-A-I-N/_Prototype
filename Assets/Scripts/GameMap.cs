using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    public float gold;
    public UnityEngine.UI.Text price;
    public UnityEngine.UI.Text Hp;
    public UnityEngine.UI.Text _wave;
    public GameObject win;
    public int gold5B;
    public int wave = 1;
    public int killedEnemies = 0;
    public int totalEnemies = 0;
    DamageCastle dc;
    public AudioSource[] audio = new AudioSource[10];
    // Start is called before the first frame update
    void Start()
    {
        dc = GetComponentInChildren<DamageCastle>();
        audio = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        int nowGold = (int)gold;
        if (dc != null)
        {
            price.text = "" + nowGold;
            Hp.text = dc.health + "/50 HP";
            _wave.text = "Wave: " + wave + " Enemies: " + killedEnemies + "/" + totalEnemies;
        }
        if(wave == 50 && (killedEnemies == totalEnemies))
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
