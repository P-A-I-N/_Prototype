using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float health = 10;
    public float rateOfFire;
    public GameObject bullet;
    private bool damage;
    private bool target;
    public int price;

    private void Start()
    {
            InvokeRepeating("criateBullet", 0, rateOfFire);
    }
    void LateUpdate()
    {
        if (damage)
        {
            health -= 0.02f;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        damage = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        damage = false;
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Boss")
        {
            target = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            target = false;
        }
    }
    private void criateBullet()
    {
        if (target)
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }
    }
    
}
