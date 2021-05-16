using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int health;
    public int price;
    public int fullprice;
    public GameObject bullet;
    public GameObject invisibleBullet;
    public GameObject levelUp;
    public Text nameTower;
    private LayerMask layerMask;
    public int hpTankBuff;
    public float _health;
    private bool damage;
    private bool target;
    public float damageEnemy = 0;


    public bool invisible;
    public bool strongBuff;
    public int range;
    public int rateOfFire;
    public float damageTower;

    private int _range;

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

    public int debuffHp;

    public int multiplyRange;
    public int multiplyRangeLvl5;
    public float multiplyDamage;
    public int multiplySpeed;
    public Transform parent;

    int B1;
    int B2;
    int B3;
    int B4;
    int B5A;
    int B5B;
    protected void Start()
    {
        parent = gameObject.transform;
        _health = health;

        _range = range;

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
    protected void OnCollisionExit2D(Collision2D collision)
    {
        damageEnemy -= collision.gameObject.GetComponent<Enemy>().damageEnemy;
        if (damageEnemy <= 0) damage = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TankBuff")
        {
            _health += hpTankBuff;
        }
        if (collision.tag == "Buff 1")
        {
            invisible = true;
            B1++;
        }
        if (collision.tag == "Buff 2")
        {
            if (B2 + B3 + B4 + B5B + B5A == 0) range += multiplyRange;
            invisible = true;
            B2++;
        }
        if (collision.tag == "Buff 3")
        {
            if (B2 + B3 + B4 + B5B + B5A == 0) range += multiplyRange;
            if (B3 + B4 + B5B + B5A == 0) damageTower += multiplyDamage;
            invisible = true;
            B3++;
        }
        if (collision.tag == "Buff 4")
        {
            if (B2 + B3 + B4 + B5B + B5A == 0) range += multiplyRange;
            if (B3 + B4 + B5B + B5A == 0) damageTower += multiplyDamage;
            if (B4 + B5B + B5A == 0) strongBuff = true;
            invisible = true;
            B4++;
        }
        if (collision.tag == "Buff 5A")
        {
            if (B2 + B3 + B4 + B5B + B5A == 0) range += multiplyRange;
            if (B3 + B4 + B5B + B5A == 0) damageTower += multiplyDamage;
            if (B4 + B5B + B5A == 0) strongBuff = true;
            if (B5A == 0) rateOfFire += multiplySpeed;
            invisible = true;
            strongBuff = true;
            B5A++;
        }
        if (collision.tag == "Buff 5B")
        {
            if (B3 + B4 + B5B + B5A == 0) damageTower += multiplyDamage;
            if (B4 + B5B + B5A == 0) strongBuff = true;
            if (B5B == 0 && range == _range + multiplyRange) range = range + multiplyRangeLvl5 - multiplyRange;
            else if (B5B == 0) range = range + multiplyRangeLvl5;
            invisible = true;
            strongBuff = true;
            B5B++;
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "TankBuff")
        {
            if (_health > hpTankBuff) _health -= hpTankBuff;
        }
        if (collision.tag == "Buff 1")
        {
            B1--;
            if (B1 + B2 + B3 + B4 + B5A + B5B == 0) invisible = false;
        }
        if (collision.tag == "Buff 2")
        {
            B2--;
            if (B1 + B2 + B3 + B4 + B5A + B5B == 0) invisible = false;
            if (B2 + B3 + B4 + B5B + B5A == 0) range -= multiplyRange;
        }
        if (collision.tag == "Buff 3")
        {
            B3--;
            if (B1 + B2 + B3 + B4 + B5A + B5B == 0) invisible = false;
            if (B2 + B3 + B4 + B5B + B5A == 0) range -= multiplyRange;
            if (B3 + B4 + B5B + B5A == 0) damageTower -= multiplyDamage;
        }
        if (collision.tag == "Buff 4")
        {
            B4--;
            if (B1 + B2 + B3 + B4 + B5A + B5B == 0) invisible = false;
            if (B2 + B3 + B4 + B5B + B5A == 0) range -= multiplyRange;
            if (B3 + B4 + B5B + B5A == 0) damageTower -= multiplyDamage;
            if (B4 + B5B + B5A == 0) strongBuff = false;
        }
        if (collision.tag == "Buff 5A")
        {
            B5A--;
            if (B1 + B2 + B3 + B4 + B5A + B5B == 0) invisible = false;
            if (B2 + B3 + B4 + B5B + B5A == 0) range -= multiplyRange;
            if (B3 + B4 + B5B + B5A == 0) damageTower -= multiplyDamage;
            if (B4 + B5B + B5A == 0) strongBuff = false;
            if (B5A == 0) rateOfFire -= multiplySpeed;
        }
        if (collision.tag == "Buff 5B")
        {
            B5B--;
            if (B1 + B2 + B3 + B4 + B5A + B5B == 0) invisible = false;
            if (B3 + B4 + B5B + B5A == 0) damageTower -= multiplyDamage;
            if (B4 + B5B + B5A == 0) strongBuff = false;
            if (B5B == 0 && B2 + B3 + B4 + B5A > 0) range = range - multiplyRangeLvl5 + multiplyRange;
            else if (B2 + B3 + B4 + B5A + B5B == 0) range -= multiplyRangeLvl5;
        }
    }
    protected void criateBullet()
    {
        if (target && !invisible)
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation, parent);
        }
        if (target && invisible)
        {
            Instantiate(invisibleBullet, transform.position, bullet.transform.rotation, parent);
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

