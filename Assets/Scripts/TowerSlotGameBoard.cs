using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSlotGameBoard : MonoBehaviour
{
    [SerializeField]
    GameObject sprite, price;
    [SerializeField]
    Sprite[] towers;
    [SerializeField]
    GameObject[] towers_build;
    [SerializeField]
    RayCast builder;
    bool active = false;
    int index = -1;
    RayCast functions_build;
    // Start is called before the first frame update
    void Start()
    {
        functions_build = builder.GetComponent<RayCast>();
        Image spr = sprite.GetComponent<Image>();
        Text price_text = price.GetComponentInChildren<Text>();
        //print(PlayerPrefs.GetString(gameObject.name));
        switch (PlayerPrefs.GetString(gameObject.name))
        {
            case "empty":
                break;
            case "Buff_Tower_Lvl_1":
                index = 5;
                spr.sprite = towers[0];
                price_text.text = towers_build[0].GetComponent<Tower>().price.ToString();
                active = true;
                break;
            case "Debuff_Tower_Lvl_1":
                index = 4;
                spr.sprite = towers[1];
                price_text.text = towers_build[1].GetComponent<Tower>().price.ToString();
                active = true;
                break;
            case "Freeze_Tower_Lvl_1":
                index = 7;
                spr.sprite = towers[2];
                price_text.text = towers_build[2].GetComponent<Tower>().price.ToString();
                active = true;
                break;
            case "Gold_Tower_Lvl_1":
                index = 3;
                spr.sprite = towers[3];
                price_text.text = towers_build[3].GetComponent<Tower>().price.ToString();
                active = true;
                break;
            case "Normal_Tower_Lvl_1":
                index = 1;
                spr.sprite = towers[4];
                price_text.text = towers_build[4].GetComponent<Tower>().price.ToString();
                active = true;
                break;
            case "PVO_Tower_Lvl_1":
                index = 9;
                spr.sprite = towers[5];
                price_text.text = towers_build[5].GetComponent<Tower>().price.ToString();
                active = true;
                break;
            case "Splash_Tower_Lvl_1":
                index = 8;
                spr.sprite = towers[6];
                price_text.text = towers_build[6].GetComponent<Tower>().price.ToString();
                active = true;
                break;
            case "Super_Tower_Lvl_1":
                index = 2;
                spr.sprite = towers[7];
                price_text.text = towers_build[7].GetComponent<Tower>().price.ToString();
                active = true;
                break;
            case "Tank_Tower_Lvl_1":
                index = 6;
                spr.sprite = towers[8];
                price_text.text = towers_build[8].GetComponent<Tower>().price.ToString();
                active = true;
                break;
            default:
                break;
        }
    }

    public void Click()
    {
        print("ready");
        switch (index)
        {
            case 1:
                functions_build.tower1();
                break;
            case 2:
                functions_build.tower2();
                break;
            case 3:
                functions_build.tower3();
                break;
            case 4:
                functions_build.tower4();
                break;
            case 5:
                functions_build.tower5();
                break;
            case 6:
                functions_build.tower6();
                break;
            case 7:
                functions_build.tower7();
                break;
            case 8:
                functions_build.tower8();
                break;
            case 9:
                functions_build.tower9();
                break;
            case 10:
                functions_build.tower10();
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
