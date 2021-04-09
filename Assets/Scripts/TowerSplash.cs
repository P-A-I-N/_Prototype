using UnityEngine;
using UnityEngine.UI;

public class TowerSplash : MonoBehaviour
{
    public int health = 10;
    public int range;
    public int rateOfFire;
    public int price;
    public GameObject bullet;
    public GameObject invisibleBullet;
    public GameObject levelUp;
    public Text nameTower;
    private LayerMask layerMask;
    private bool invisible;
    private float _health;
    private bool damage;
    private bool target;
    private int num_enemies = 0;

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
    void LateUpdate()
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        num_enemies++;
        damage = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        num_enemies--;
        if (num_enemies <= 0) damage = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "TowerBuff")
        {
            invisible = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "TowerBuff")
        {
            invisible = false;
        }
    }
    private void criateBullet()
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
