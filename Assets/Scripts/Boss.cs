using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;
    public GameObject gameWin;
    private float _speed;
    public float health = 50;

    private void Awake()
    {
        gameWin = GameObject.Find("Canvas");
        _speed = speed;
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

        _speed = 0;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            health--;
        }
    }
}
