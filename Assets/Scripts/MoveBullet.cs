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
        if (((gameObject.tag == "BulletCold" || gameObject.tag == "Bullet") || gameObject.tag == "BulletNormalLvl5A") && (collision.tag == "Enemy" || collision.tag == "Boss"))
        {
            Destroy(gameObject);
        }
        if ((((gameObject.tag == "BulletPVO" || gameObject.tag == "InvisibleBulletPVO") || gameObject.tag == "BulletNormalLvl5A") || gameObject.tag == "InvisibleBulletNormalLvl5A") && collision.tag == "EnemyVO")
        {
            Destroy(gameObject);
        }
        if ((((gameObject.tag == "InvisibleBullet" || gameObject.tag == "InvisibleBulletFreeze") || gameObject.tag == "BulletNormalLvl5A") || gameObject.tag == "InvisibleBulletNormalLvl5A") && ((collision.tag == "Enemy" || collision.tag == "Boss") || collision.tag == "EnemyInvisible"))
        {
            Destroy(gameObject);
        }
    }
}
