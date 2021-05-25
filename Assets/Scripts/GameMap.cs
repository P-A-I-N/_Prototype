using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    public float gold = 1000;
    public UnityEngine.UI.Text InfoBar;
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
        if (dc != null) InfoBar.text = dc.health + "/50 HP Gold:" + gold + " Wave:" + wave + " Enemies: " + killedEnemies + "/" + totalEnemies;
    }
}
