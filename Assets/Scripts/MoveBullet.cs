using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed;
    public Transform parent;
    public float parentPos = 30;
    public float pos;
    public float x;
    public float range;

    public bool Splash;
    public bool Freeze;
    public bool Invisible;
    public bool PVO;
    public bool Strong;
    public bool Normal;

    private void Update()
    {
        if (Splash)
        {
            x = parentPos + range;
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
        if (PVO && enemyPVO)
        {
            Destroy(gameObject);
        }
        if (Invisible && !Splash && (!PVO || (Normal && PVO)) && !enemyPVO)
        {
            Destroy(gameObject);
        }
        if (Splash)
        {
            if (!enemyPVO && !enemyInvisible && !Invisible)
            {
                if(enemyStrong)
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
                else if(parent == null)
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
