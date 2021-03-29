using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed;
    void LateUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((gameObject.tag == "BulletCold" || gameObject.tag == "Bullet") && collision.tag != "EnemyPVO" && (collision.tag == "Enemy" || collision.tag == "Boss"))
        {
            Destroy(gameObject);
        }
        if (gameObject.tag == "BulletPVO" && collision.tag == "EnemyVO" && collision.tag != "Enemy" && collision.tag != "Boss")
        {
            Destroy(gameObject);
        }
    }
}
