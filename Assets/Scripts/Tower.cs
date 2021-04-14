using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int health = 10;
    public int range;
    public int rateOfFire;
    public int price;
    public int fullprice;
    public GameObject bullet;
    public GameObject invisibleBullet;
    public GameObject levelUp;
    public Text nameTower;
    protected LayerMask layerMask;
    protected bool invisible;
    public float _health;
    public bool damage;
    protected bool target;
    protected int num_enemies = 0;


    protected void Awake()
    {
        _health = health;
    }
    protected void Start()
    {
        if (fullprice <= 0) fullprice = price;
        InvokeRepeating("criateBullet", 0, rateOfFire);
    }

    protected void Update()
    {
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int enemyInvisibleLayer = LayerMask.NameToLayer("EnemyInvisible");
        if (invisible)
        {
            layerMask = ((1 << enemyLayer) | (1 << enemyInvisibleLayer));
        }
        else
        {
            layerMask = (1 << enemyLayer);
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, layerMask);
        Debug.DrawRay(transform.position, Vector2.right * range, Color.yellow);
        if (hit.collider != null)
        {
            target = true;
        }
        else target = false;
    }
    protected void LateUpdate()
    {
        if (damage)
        {
            _health -= 0.01f * num_enemies;
        }

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        num_enemies++;
        damage = true;
    }
    protected void OnCollisionExit2D(Collision2D collision)
    {
        num_enemies--;
        if (num_enemies <= 0) damage = false;
    }
    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "TowerBuff")
        {
            invisible = true;
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "TowerBuff")
        {
            invisible = false;
        }
    }
    protected void criateBullet()
    {
        if (target && !invisible)
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }
        if (target && invisible)
        {
            Instantiate(invisibleBullet, transform.position, bullet.transform.rotation);
        }
    }
}
