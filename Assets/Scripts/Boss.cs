using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;
    public GameObject gameWin;
    private float _speed;
    public float health = 50;
    public float coldTime;
    public float decelerationIn;
    public int debuffHp;
    bool cold;
    float timeCold;
    bool stop;
    bool debuff;
    bool _debuff;

    private void Awake()
    {
        gameWin = GameObject.Find("Canvas");
        _speed = speed;
    }
    private void Update()
    {
        if (debuff && !_debuff)
        {
            health -= debuffHp;
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
        if (Time.time > timeCold && !stop)
        {
            _speed = speed;
        }
    }
    void LateUpdate()
    {
        if (health <= 0)
        {
            gameWin.transform.GetChild(0).gameObject.SetActive(true);
            gameWin.transform.GetChild(1).gameObject.SetActive(false);
            Time.timeScale = 0;
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Castle")
        {
            Destroy(gameObject);
        }
        stop = true;
        _speed = 0;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        stop = false;
        _speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((collision.tag == "Bullet" || collision.tag == "InvisibleBulletSplash") || collision.tag == "InvisibleBullet") || collision.tag == "BulletSplash")
        {
            health--;
        }
        if (collision.tag == "BulletCold" || collision.tag == "InvisibleBulletFreeze")
        {
            health--;
            cold = true;
        }
        if (collision.tag == "TowerDebuff")
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
