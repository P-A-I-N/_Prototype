using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    public float gold = 50;
    public UnityEngine.UI.Text price;
    public UnityEngine.UI.Text Hp;
    public UnityEngine.UI.Text _wave;
    public int gold5B;
    public int wave = 1;
    public int killedEnemies = 0;
    public int totalEnemies = 0;
    DamageCastle dc;
    // Start is called before the first frame update
    void Start()
    {
        dc = GetComponentInChildren<DamageCastle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dc != null)
        {
            price.text = "" + gold;
            Hp.text = dc.health + "/50 HP";
            _wave.text = "Wave: " + wave + " Enemies: " + killedEnemies + "/" + totalEnemies;
        }
    }
}
