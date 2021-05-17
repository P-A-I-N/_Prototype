using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float freezeTime;
    public float decelerationIn;
    public float gold;
    public float max_health;
    private float _speed;
    GameMap gm;
    bool cold;
    float timeCold;
    bool stop;
    LineRenderer HPBar;
    public float damageTower;
    public float damageEnemy;

    public bool enemyStrong;
    public bool enemyPVO;
    public bool enemyInvisible;
    public bool _enemyStrong;
    public bool _enemyPVO;
    public bool _enemyInvisible;

    public string tipe;
    public string lvl;


    public float fireDamage;
    public float timeFire;
    public float damageRetryTime;
    private float xtime;

    private bool Fire;

    bool Freeze;
    bool Invisible;
    bool PVO;
    bool Strong;
    bool Normal;
    bool Splash;
    bool SplashFreeze;

    public int percentOfEnemy;

    public float dbHp;
    public float poisonDamage;
    public float timeBetweenDamage;
    public float dbSpeed;
    public bool x3Damage;
    public bool besiege;
    public bool change;

    private float nowDbHp;
    private float _dbHp;

    private float nowDbSpeed;
    private float _dbSpeed;

    public int numLater;
    public string _layer;

    public bool changeTower;
    private void Awake()
    {
        if (max_health <= 0) max_health = health;
        _speed = speed;
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
        GetComponent<SpriteRenderer>().sortingLayerName = "Enemy";
        HPBar = GetComponent<LineRenderer>();
        HPBar.useWorldSpace = false;
        HPBar.startWidth = 0.1f;
        HPBar.endWidth = 0.1f;
        HPBar.SetPosition(0, new Vector3(-0.5f, 0.8f));
        HPBar.SetPosition(1, new Vector3(0.5f, 0.8f));
        HPBar.sortingLayerName = "Enemy";
        HPBar.startColor = Color.red;
        HPBar.endColor = Color.red;
        HPBar.sortingOrder = 10;
    }
    private void Start()
    {
        _speed = speed;

        _enemyInvisible = enemyInvisible;
        _enemyPVO = enemyPVO;
        _enemyStrong = enemyStrong;
        numLater = gameObject.layer;
        _layer = LayerMask.LayerToName(numLater);

        InvokeRepeating("fire", 0, damageRetryTime);
        InvokeRepeating("poison", 0.0f, timeBetweenDamage);
    }
    private void Update()
    {
        if (dbHp != gameObject.GetComponent<Debuff>().dbHp) dbHp = gameObject.GetComponent<Debuff>().dbHp;
        if (poisonDamage != gameObject.GetComponent<Debuff>().poisonDamage) poisonDamage = gameObject.GetComponent<Debuff>().poisonDamage;
        // (timeBetweenDamage != gameObject.GetComponent<Debuff>().timeBetweenDamage) timeBetweenDamage = gameObject.GetComponent<Debuff>().timeBetweenDamage;
        if (dbSpeed != gameObject.GetComponent<Debuff>().dbSpeed) dbSpeed = gameObject.GetComponent<Debuff>().dbSpeed;
        if (x3Damage != gameObject.GetComponent<Debuff>().x3Damage) x3Damage = gameObject.GetComponent<Debuff>().x3Damage;
        if (besiege != gameObject.GetComponent<Debuff>().besiege) besiege = gameObject.GetComponent<Debuff>().besiege;
        if (change != gameObject.GetComponent<Debuff>().change) change = gameObject.GetComponent<Debuff>().change;

        if (dbHp != nowDbHp)
        {
            _dbHp = nowDbHp - dbHp;
            nowDbHp = dbHp;
            health += _dbHp;
        }
        if (dbSpeed != nowDbSpeed)
        {
            _dbSpeed = nowDbSpeed - dbSpeed;
            nowDbSpeed = dbSpeed;
            _speed += _dbSpeed;
            speed += _dbSpeed;
        }
        if(besiege)
        {
            enemyInvisible = false;
            enemyPVO = false;
            enemyStrong = false;
            gameObject.layer = LayerMask.NameToLayer("Enemy");
        }
        else
        {
            enemyInvisible = _enemyInvisible;
            enemyPVO = _enemyPVO;
            enemyStrong = _enemyStrong;
            gameObject.layer = LayerMask.NameToLayer(_layer);
        }
        if(change && changeTower)
        {
            Debug.Log("3");
        }


        HPBar.SetPosition(1, new Vector3(-0.5f + health / max_health, 0.8f));
        if (cold && _speed == speed)
        {
            _speed /= decelerationIn;
            timeCold = Time.time + freezeTime;
            cold = false;
        }
        if (Time.time > timeCold && !stop)
        {
            _speed = speed;
        }
        if (health <= 0)
        {
            gold = gold + ((gold / 100) * (percentOfEnemy * gm.gold5B));
            gm.gold += gold;
            Destroy(gameObject);
        }
        if (Fire)
        {
            if (xtime < Time.time)
            {
                Fire = false;

            }
        }

    }
    private void LateUpdate()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Castle")
        {
            Destroy(gameObject);
        }
        if (!enemyPVO)
        {
            stop = true;
            _speed = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!enemyPVO)
        {
            stop = false;
            _speed = speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MoveBullet>())
        {
            Freeze = collision.gameObject.GetComponent<MoveBullet>().Freeze;
            Invisible = collision.gameObject.GetComponent<MoveBullet>().Invisible;
            PVO = collision.gameObject.GetComponent<MoveBullet>().PVO;
            Strong = collision.gameObject.GetComponent<MoveBullet>().Strong;
            Normal = collision.gameObject.GetComponent<MoveBullet>().Normal;
            Splash = collision.gameObject.GetComponent<MoveBullet>().Splash;
            SplashFreeze = collision.gameObject.GetComponent<MoveBullet>().SplashFreeze;
            damageTower = collision.gameObject.GetComponent<MoveBullet>().damageTower;
        }


        if (x3Damage)
        {
            damageTower *= 3;
        }
        if (collision.tag == "Fire")
        {
            Fire = true;
            xtime = Time.time + timeFire;
        }

        if (Freeze)
        {
            freezeTime = collision.gameObject.GetComponent<MoveBullet>().freezeTime;
            decelerationIn = collision.gameObject.GetComponent<MoveBullet>().decelerationIn;
        }



        if (!Invisible && !Freeze && !enemyPVO && !enemyInvisible)
        {
            if (!enemyStrong && (Normal || (Splash && !PVO))) health -= damageTower;
            else if (Normal && Strong) health -= damageTower;
        }
        if (PVO && enemyPVO && !enemyInvisible)
        {
            if (!enemyStrong) health -= damageTower;
            else if (Strong && enemyStrong) health -= damageTower;
        }
        if (!Invisible && Freeze && !enemyPVO && !enemyInvisible)
        {
            if (!enemyStrong && !SplashFreeze)
            {
                health -= damageTower;
                cold = true;
            }
            else cold = true;
        }
        if (Invisible && !Freeze && (!PVO || (PVO && Normal)) && !enemyStrong && !enemyPVO)
        {
            health -= damageTower;
        }
        if (Invisible && Freeze && !enemyPVO)
        {
            if (!enemyStrong && !SplashFreeze)
            {
                health -= damageTower;
                cold = true;
            }
            else cold = true;
        }
    }
    private void fire()
    {
        if (Fire)
        {
            health -= fireDamage;
        }
    }
    private void poison()
    {
        health -= poisonDamage;
    }





}
