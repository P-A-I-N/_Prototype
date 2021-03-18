using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    public int gold = 1000;
    public UnityEngine.UI.Text InfoBar;
    DamageCastle dc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dc = GetComponentInChildren<DamageCastle>();
        if (dc != null) InfoBar.text = dc.health + "/50 HP Gold:" + gold;
    }
}
