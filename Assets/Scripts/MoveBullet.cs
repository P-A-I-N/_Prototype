﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed;
    public Transform parent;
    public float parentPos;
    public float pos;
    public float x;
    public int rangeSplash;

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

    private void Start()
    {
        TextAsset xmlAsset = (TextAsset)Resources.Load("config");
        Debug.Log(xmlAsset);

        XmlDocument xmlDoc = new XmlDocument();
        if (xmlAsset) xmlDoc.LoadXml(xmlAsset.text);
        Debug.Log("root/Tower/" + tipe + "/Lvl" + lvl);
        foreach (XmlNode Tower in xmlDoc.SelectNodes("root/Tower/" + tipe + "/Lvl" + lvl))
        {
            Debug.Log("root/Tower/" + tipe + "/Lvl" + lvl);

            speed = float.Parse(Tower.Attributes.GetNamedItem("SpeedBullet").Value);
            Debug.Log(speed);
            if(Splash)
            {
                rangeSplash = int.Parse(Tower.Attributes.GetNamedItem("RangeSplash").Value);
                Debug.Log(rangeSplash);
            }
        }
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
        }
    }
    void LateUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool enemyStrong = collision.gameObject.GetComponent<Enemy>().enemyStrong;
        bool enemyPVO = collision.gameObject.GetComponent<Enemy>().enemyPVO;
        bool enemyInvisible = collision.gameObject.GetComponent<Enemy>().enemyInvisible;



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
            if(Freeze)
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
                    speed *= 10;
                    SplashFreeze = true;
                }
            }
            if(enemyPVO && PVO)
            {
                if(!enemyPVO)
                {
                    Destroy(gameObject);
                }
                else if(parent == null)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    parent = collision.transform;
                    parentPos = parent.position.x;
                    speed *= 10;
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
                    speed *= 10;
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
                    speed *= 10;
                }
            }
        }
    }
}
