﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private float _speed;
    public float health;
    public float max_health;
    public float coldTime;
    public float decelerationIn;
    public int debuffHp;
    public int gold;
    GameMap gm;
    bool cold;
    float timeCold;
    bool stop;
    bool debuff;
    bool _debuff;
    LineRenderer HPBar;

    public bool strong;

    private void Awake()
    {
        if (max_health <= 0) max_health = health;
        _speed = speed;
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
        GetComponent<SpriteRenderer>().sortingLayerName = "Enemy";
        HPBar = GetComponent<LineRenderer>();
        HPBar.useWorldSpace = false;
        HPBar.startWidth = 0.1f;
        HPBar.endWidth = 0.1f;
        HPBar.SetPosition(0, new Vector3(-0.5f, 0.8f));
        HPBar.SetPosition(1, new Vector3(0.5f, 0.8f));
        HPBar.sortingLayerName = "Enemy";
        HPBar.startColor = Color.red;
        HPBar.endColor = Color.red;
        HPBar.sortingOrder = 10;
    }
    private void Update()
    {
        HPBar.SetPosition(1, new Vector3(-0.5f + health/max_health, 0.8f));
        if(debuff && !_debuff)
        {
            health -=debuffHp;
            _debuff = true;
        }
        if (!debuff && _debuff)
        {
            health += debuffHp;
            _debuff = false;
        }
        if (cold && _speed == speed)
        {
            _speed /= decelerationIn;
            timeCold = Time.time + coldTime;
            cold = false;
        }
        if(Time.time > timeCold && !stop)
        {
            _speed = speed;
        }  
        
        if(health <= 0)
        {
            Destroy(gameObject);
            gm.gold += gold;
        }
        
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Castle")
        {
            Destroy(gameObject);
        }
        if (gameObject.tag != "EnemyVO")
        {
            stop = true;
            _speed = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (gameObject.tag != "EnemyVO")
        {
            stop = false;
            _speed = speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((((((collision.tag == "Bullet" || collision.tag == "InvisibleBullet") || collision.tag == "InvisibleBulletSplash") || collision.tag == "BulletSplash") || collision.tag == "BulletNormalLvl5A") || collision.tag == "InvisibleBulletNormalLvl5A") && gameObject.tag == "Enemy") && !strong)
        {
            health--;
        }
        if (((((collision.tag == "BulletPVO" || collision.tag == "InvisibleBulletPVO") || collision.tag == "BulletNormalLvl5A") || collision.tag == "InvisibleBulletNormalLvl5A") && gameObject.tag == "EnemyVO") && !strong)
        {
            health--;
        }
        if ((collision.tag == "BulletCold" || collision.tag == "InvisibleBulletFreeze") && gameObject.tag == "Enemy")
        {
            if (!strong)
            {
                health--;
                cold = true;
            }
            else
            {
                cold = true;
            }
        }
        if ((((collision.tag == "InvisibleBullet" || collision.tag == "InvisibleBulletSplash") || collision.tag == "InvisibleBulletNormalLvl5A") && gameObject.tag == "EnemyInvisible") && !strong)
        {
            health--;
        }
        if (collision.tag == "InvisibleBulletFreeze" && gameObject.tag == "EnemyInvisible")
        {
            if (!strong)
            {
                health--;
                cold = true;
            }
            else
            {
                cold = true;
            }
        }
        if(collision.tag == "TowerDebuff")
        {
            debuff = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "TowerDebuff")
        {
            debuff = false;
        }
    }
}
