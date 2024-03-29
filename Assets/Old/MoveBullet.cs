﻿using UnityEngine;
using UnityEditor;

public class MoveBullet : MonoBehaviour
{
    public float speed;
    public Transform parent;
    public float parentPos;
    public float pos;
    public float x;
    public int rangeSplash;
    public float damageTower;

    public bool Fire;
    public bool SplashFreeze;
    public bool Splash;
    public bool Freeze;
    public bool Invisible;
    public bool PVO;
    public bool Strong;
    public bool Normal;

    public string tipe;
    public string lvl;

    public int numSplashFreeze;

    public float freezeTime;
    public float decelerationIn;

    bool enemyStrong;
    bool enemyPVO;
    bool enemyInvisible;

    private void Start()
    {
        damageTower += GetComponentInParent<Tower_old>().damageTower;
        if (GetComponentInParent<Tower_old>().strongBuff == true) Strong = true;
    }
    private void Update()
    {
        if (Splash)
        {
            x = parentPos + rangeSplash;
            pos = transform.position.x;
            if (pos > x)
            {
                Destroy(gameObject);
            }
            if (Freeze && parent != null)
            {
                SplashFreeze = true;
            }
        }
    }
    void LateUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            enemyStrong = collision.gameObject.GetComponent<Enemy>().enemyStrong;
            enemyPVO = collision.gameObject.GetComponent<Enemy>().enemyPVO;
            enemyInvisible = collision.gameObject.GetComponent<Enemy>().enemyInvisible;
        }

        if (collision.tag == "Border")
        {
            Destroy(gameObject);
        }

        if ((!PVO || (Normal && PVO)) && !Splash && !enemyPVO && !enemyInvisible)
        {
            Destroy(gameObject);
        }
        if (PVO && enemyPVO && !Splash)
        {
            Destroy(gameObject);
        }
        if (Invisible && !Splash && (!PVO || (Normal && PVO)) && !enemyPVO)
        {
            Destroy(gameObject);
        }
        if (Splash)
        {
            if (Freeze)
            {
                if (enemyStrong)
                {
                    Destroy(gameObject);
                }
                else if (parent == null)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    parent = collision.transform;
                    parentPos = parent.position.x;
                    speed *= 2;
                }
            }
            if (enemyPVO && PVO)
            {
                if (!enemyPVO)
                {
                    Destroy(gameObject);
                }
                else if (parent == null)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    parent = collision.transform;
                    parentPos = parent.position.x;
                    speed *= 2;
                }
            }
            if (!enemyPVO && !enemyInvisible && !Invisible && !Freeze)
            {
                if (enemyStrong)
                {
                    Destroy(gameObject);
                }
                else if (parent == null)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    parent = collision.transform;
                    parentPos = parent.position.x;
                    speed *= 2;
                }
            }
            if (!enemyPVO && Invisible)
            {
                if (enemyStrong)
                {
                    Destroy(gameObject);
                }
                else if (parent == null)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    parent = collision.transform;
                    parentPos = parent.position.x;
                    speed *= 2;
                }
            }
        }
    }
}
