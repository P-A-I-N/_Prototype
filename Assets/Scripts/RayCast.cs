﻿using UnityEngine;

public class RayCast : MonoBehaviour
{
    private Vector3 pos;
    public GameObject[] towers;
    private GameObject tower;
    private LayerMask layerTower = 1 << 8;
    private LayerMask layerPoint = 1 << 7;



    void Update()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitTower = Physics2D.Raycast(worldPoint, Vector2.zero, 100f, layerTower);
        RaycastHit2D hitPoint = Physics2D.Raycast(worldPoint, Vector2.zero, 100f, layerPoint);

        if (Input.GetMouseButtonDown(0) && hitTower.collider != null && tower == null)
        {
            Destroy(hitTower.collider.gameObject);
        }

        if (Input.GetMouseButtonDown(0) && hitTower.collider == null && hitPoint.collider != null && tower != null)
        {
            pos = hitPoint.collider.gameObject.transform.position;
            Instantiate(tower, pos, tower.transform.rotation);
        }

    }





    public void tower1()
    {
        tower = towers[0];
    }
    public void tower2()
    {
        tower = towers[1];
    }
    public void tower3()
    {
        tower = towers[2];
    }
    public void tower4()
    {
        tower = towers[3];
    }
    public void tower5()
    {
        tower = towers[4];
    }
    public void tower6()
    {
        tower = towers[5];
    }
    public void tower7()
    {
        tower = towers[6];
    }
    public void tower8()
    {
        tower = towers[7];
    }
    public void tower9()
    {
        tower = towers[8];
    }
    public void deleteTower()
    {
        tower = null;
    }
}

