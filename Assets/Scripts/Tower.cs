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

    public float range;
    public float rateOfFire;
    public float _rateOfFire;
    public float damageTower;

    public bool lvl4;
    public GameObject lvl5a;
    public GameObject lvl5b;

    public bool goldTower;

    GameMap gm;
    public float goldGet;
    public float goldDelay;

    public bool PVO;
    public bool PNO;

    public string tipe;
    public string lvl;
    public float percentOfGold;

    public int debuffHp;

    public bool invisible;
    public bool strongBuff;
    public float multiplyRange;
    public float multiplyDamage;
    public float multiplySpeed;
    public Transform parent;

    public float _multiplyRange;
    public float _multiplyDamage;
    public float _multiplySpeed;

    public float nowMultiplyRange;
    public float nowMultiplyDamage;
    public float nowMultiplySpeed;

    public Animator anim;

    
    protected void Start()
    {
        parent = gameObject.transform;
        _health = health;
        _rateOfFire = rateOfFire;

        if (fullprice <= 0) fullprice = price;
        //if (PNO || PVO) InvokeRepeating("criateBullet", 0, rateOfFire);

        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
        if (goldTower) InvokeRepeating("GetGold", 0, goldDelay);
        if (tipe == "Gold" && lvl == "5B")
        {
            gm.gold5B++;
        }
    }

    protected void Update()
    {
        if (rateOfFire < Time.time && target)
        {
            criateBullet();
        }

        if (gameObject.GetComponent<Buff>() != null)
        {
            if (invisible != gameObject.GetComponent<Buff>().invisible) invisible = gameObject.GetComponent<Buff>().invisible;
            if (strongBuff != gameObject.GetComponent<Buff>().strong) strongBuff = gameObject.GetComponent<Buff>().strong;
            if (multiplyRange != gameObject.GetComponent<Buff>().multiplyRange) multiplyRange = gameObject.GetComponent<Buff>().multiplyRange;
            if (multiplyDamage != gameObject.GetComponent<Buff>().multiplyDamage) multiplyDamage = gameObject.GetComponent<Buff>().multiplyDamage;
            if (multiplySpeed != gameObject.GetComponent<Buff>().multiplySpeed) multiplySpeed = gameObject.GetComponent<Buff>().multiplySpeed;
        }
        else return;

        if (multiplyRange != nowMultiplyRange)
        {
            _multiplyRange = nowMultiplyRange - multiplyRange;
            nowMultiplyRange = multiplyRange;
            range -= _multiplyRange;
        }
        if (multiplyDamage != nowMultiplyDamage)
        {
            _multiplyDamage = nowMultiplyDamage - multiplyDamage;
            nowMultiplyDamage = multiplyDamage;
            damageTower -= _multiplyDamage;
        }
        if (multiplySpeed != nowMultiplySpeed)
        {
            _multiplySpeed = nowMultiplySpeed - multiplySpeed;
            nowMultiplySpeed = multiplySpeed;
            if (_rateOfFire + _multiplySpeed <= 0.5f)
            {
                _rateOfFire = 0.5f;
            }
            else _rateOfFire += _multiplySpeed;
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
            _health -= damageEnemy * Time.deltaTime;
        }

        if (_health <= 0)
        {
            anim.SetInteger("state", 2);
        }

        if (tipe == "Gold" && lvl == "5A")
        {
            float nowGold = gm.gold;
            goldGet = (nowGold / 100) * percentOfGold;
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
        rateOfFire = _rateOfFire;
        rateOfFire += Time.time;
    }
    void GetGold()
    {
        gm.gold += goldGet;
    }

    public void lvl5A()
    {
        levelUp = lvl5a;
    }

    public void lvl5B()
    {
        levelUp = lvl5b;
    }
    public void die()
    {
        if (tipe == "Gold" && lvl == "5B")
        {
            gm.gold5B--;
        }
        Destroy(gameObject);
    }
}

