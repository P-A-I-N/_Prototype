using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTower : Tower
{
    GameMap gm;
    public int goldGet, goldDelay;
    // Start is called before the first frame update
    new void Start()
    {
        if (fullprice <= 0) fullprice = price;
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
        if (goldGet <= 0) goldGet = 1;
        if (goldDelay <= 0) goldDelay = 10;
        InvokeRepeating("GetGold", goldDelay, goldDelay);
    }
    // Update is called once per frame
    void GetGold ()
    {
        gm.gold += goldGet;
    }
}
