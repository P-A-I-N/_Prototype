using System.IO;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int health;
    public int range;
    public int rateOfFire;
    public int price;
    public int fullprice;
    public GameObject bullet;
    public GameObject invisibleBullet;
    public GameObject levelUp;
    public Text nameTower;
    private LayerMask layerMask;
    private bool invisible;
    public int hpTankBuff;
    public float _health;
    private bool damage;
    private bool target;
    public float damageEnemy = 0;

    public bool lvl4;
    public GameObject lvl5a;
    public GameObject lvl5b;

    public bool goldTower;

    GameMap gm;
    public float goldGet, goldDelay;

    public bool PVO;
    public bool PNO;

    public string tipe;
    public string lvl;

    public int percentOfGold;

    XmlDocument xmlDoc;


    protected void Start()
    {
        _health = health;

        if (fullprice <= 0) fullprice = price;
        if (PNO || PVO) InvokeRepeating("criateBullet", 0, rateOfFire);

        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
        if (goldTower) InvokeRepeating("GetGold", 0, goldDelay);
        if (tipe == "Gold" && lvl == "5B")
        {
            gm.gold5B++;
        }
    }

    protected void Update()
    {
        if (tipe == "Gold" && lvl == "5A")
        {
            float nowGold = gm.gold;
            goldGet = (nowGold / 100) * percentOfGold;
        }


        if (PNO)
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
            Debug.DrawRay(transform.position, Vector2.right * range, Color.white);
            if (hit.collider != null)
            {
                target = true;
            }
            else target = false;
        }

        if (PVO)
        {
            int enemyLayer = LayerMask.NameToLayer("EnemyFly");
            layerMask = (1 << enemyLayer);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, layerMask);
            Debug.DrawRay(transform.position, Vector2.right * range, Color.white);
            if (hit.collider != null)
            {
                target = true;
            }
            else target = false;
        }

        if (PVO && PNO)
        {
            int enemyLayer = LayerMask.NameToLayer("Enemy");
            int enemyInvisibleLayer = LayerMask.NameToLayer("EnemyInvisible");
            int enemyFlyLayer = LayerMask.NameToLayer("EnemyFly");
            if (invisible)
            {
                layerMask = ((1 << enemyLayer | 1 << enemyInvisibleLayer) | 1 << enemyFlyLayer);
            }
            else
            {
                layerMask = (1 << enemyLayer | 1 << enemyFlyLayer);
            }
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, layerMask);
            Debug.DrawRay(transform.position, Vector2.right * range, Color.white);
            if (hit.collider != null)
            {
                target = true;
            }
            else target = false;
        }
    }
    protected void LateUpdate()
    {
        if (damage)
        {
            _health -= damageEnemy;
        }

        if (_health <= 0)
        {
            if (tipe == "Gold" && lvl == "5B")
            {
                gm.gold5B--;
            }
            Destroy(gameObject);
        }
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        damageEnemy += collision.gameObject.GetComponent<Enemy>().damageEnemy;
        damage = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TankBuff")
        {
            foreach (XmlNode TankBuff in xmlDoc.SelectNodes("root/Tower/Tank/Lvl5B"))
            {
                hpTankBuff = int.Parse(TankBuff.Attributes.GetNamedItem("HpTankBuff").Value);
                _health += hpTankBuff;
            }
        }
    }
    protected void OnCollisionExit2D(Collision2D collision)
    {
        damageEnemy -= collision.gameObject.GetComponent<Enemy>().damageEnemy;
        if (damageEnemy <= 0) damage = false;
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
        if (collision.tag == "TankBuff")
        {
            if (_health >= hpTankBuff) _health -= hpTankBuff;
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

    public void lvl5A()
    {
        levelUp = lvl5a;
    }

    public void lvl5B()
    {
        levelUp = lvl5b;
    }
    void GetGold()
    {
        gm.gold += goldGet;
    }
}

