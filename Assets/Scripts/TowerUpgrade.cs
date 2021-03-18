using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public GameObject towerLvlUp;
    public GameObject upgradeWindow;
    public GameObject canvas;

    private void Awake()
    {
        //towerLvlUp = GameObject.Find("Canvas");
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Instantiate(upgradeWindow,transform.position,transform.rotation, transform.SetParent(Instantiate(towerLvlUp).transform));
            Instantiate(upgradeWindow, transform.position, transform.rotation).transform.SetParent(canvas.transform);

        }
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(upgradeWindow);
        }
    }
    void lavelUp()
    {
        Destroy(gameObject);
        Instantiate(towerLvlUp, transform.position, transform.rotation);
    }
}
