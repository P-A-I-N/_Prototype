using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public GameObject towerLvlUp;
    public GameObject upgradeWindow;
    public Transform parent;
    private GameObject e;

    private void Awake()
    {
        //towerLvlUp = GameObject.Find("Canvas");
    }
    private void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    //Instantiate(upgradeWindow,transform.position,transform.rotation, transform.SetParent(Instantiate(towerLvlUp).transform));
        //    e = Instantiate(upgradeWindow, transform.position, transform.rotation);
        //    e.transform.SetParent(parent);

        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    Destroy(upgradeWindow);
        //}
    }
    void lavelUp()
    {
        Destroy(gameObject);
        Instantiate(towerLvlUp, transform.position, transform.rotation);
    }
}
