﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int health = 10;
    public int range;
    public int rateOfFire;
    public int price;
    public GameObject bullet;
    public GameObject levelUp;
    public Text nameTower;
    public int targetAmount;
    private float _health;
    private bool damage;
    private bool target;
    private int num_enemies = 0;
    public LayerMask layerEnemy;
    public Transform parent;

    private void Awake()
    {
        _health = health;
    }
    private void Start()
    {
        InvokeRepeating("criateBullet", 0, rateOfFire);
        parent = gameObject.transform;
    }

    private void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, layerEnemy);
        Debug.DrawRay(transform.position, Vector2.right * range, Color.yellow);
        if (hit.collider != null)
        {
            target = true;
        }
        else target = false;
    }
    void LateUpdate()
    {
        if (damage)
        {
            _health -= 0.01f * num_enemies;
        }

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        num_enemies++;
        damage = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        num_enemies--;
        if (num_enemies <= 0) damage = false;
    }

    private void criateBullet()
    {
        if (target)
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation, parent);
        }
    }
}
