using System.Collections;
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
    private LayerMask layerEnemy = 1 << 6;

    private void Awake()
    {
        _health = health;
    }
    private void Start()
    {
        InvokeRepeating("criateBullet", 0, rateOfFire);
    }

    private void Update()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, layerEnemy);
        Debug.DrawRay(transform.position, Vector2.right * range, Color.yellow);

        if (hit.collider != null) target = true;
        else target = false;
    }
    void LateUpdate()
    {
        if (damage)
        {
            _health -= 0.02f;
        }

        if (_health <= 0)
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

    private void criateBullet()
    {
        if (target)
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }
    }
    
}
