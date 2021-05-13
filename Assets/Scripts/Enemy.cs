using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    private float _health;
    public float freezeTime;
    public float decelerationIn;
    public int debuffHp;
    public float gold;
    public float max_health;
    private float _speed;
    GameMap gm;
    bool cold;
    float timeCold;
    bool stop;
    bool debuff;
    bool _debuff;
    LineRenderer HPBar;
    public float damageTower;
    public float damageEnemy;

    public bool enemyStrong;
    public bool enemyPVO;
    public bool enemyInvisible;

    public string tipe;
    public string lvl;


    public float fireDamage;
    public float timeFire;
    public float damageRetryTime;
    private float xtime;

    private bool Fire;



    public int percentOfEnemy;

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
        _health = health;

        _speed = speed;

        InvokeRepeating("fire", 0, damageRetryTime);
    }
    private void Update()
    {
        HPBar.SetPosition(1, new Vector3(-0.5f + health / max_health, 0.8f));
        if (debuff && !_debuff)
        {
            if (debuffHp < health) health -= debuffHp;
            else health = 1;
            _debuff = true;
        }
        if (!debuff && _debuff)
        {
            if ((health + debuffHp) <= _health) health += debuffHp;
            else health = _health;
            _debuff = false;
        }
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
        bool Freeze = collision.gameObject.GetComponent<MoveBullet>().Freeze;
        bool Invisible = collision.gameObject.GetComponent<MoveBullet>().Invisible;
        bool PVO = collision.gameObject.GetComponent<MoveBullet>().PVO;
        bool Strong = collision.gameObject.GetComponent<MoveBullet>().Strong;
        bool Normal = collision.gameObject.GetComponent<MoveBullet>().Normal;
        bool Splash = collision.gameObject.GetComponent<MoveBullet>().Splash;
        bool SplashFreeze = collision.gameObject.GetComponent<MoveBullet>().SplashFreeze;
        damageTower = collision.gameObject.GetComponent<MoveBullet>().damageTower;



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
        if (collision.tag == "TowerDebuff")
        {
            debuffHp = collision.gameObject.GetComponent<Tower>().debuffHp;
            debuff = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "TowerDebuff")
        {
            debuff = false;
        }
    }
    private void fire()
    {
        if (Fire)
        {
            health -= fireDamage;
        }
    }
}
