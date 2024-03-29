﻿using UnityEngine;
using Unity;

public class Enemy : MonoBehaviour
{
    public float _speed;
    public float speed;
    public float health;
    public float health_m = 1;
    public float freezeTime;
    public float decelerationIn;
    public float gold;
    public float max_health;
    public int wave;
    GameMap gm;
    bool cold;
    float timeCold;
    bool stop;
    LineRenderer HPBar;
    public float damageTower;
    public float damageEnemy;
    public float _damageEnemy;
    public float damage_m = 1;

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
    private Vector2 vect;
    public float speedAttack;

    public Animator anim;
    AudioSource eating, drinking;
    bool change_params = true;

    private void Awake()
    {
        _speed = speed;
        if (max_health <= 0) max_health = health;
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
        gm.layerEnemy ++;
        GetComponent<SpriteRenderer>().sortingOrder = gm.layerEnemy;
        GetComponent<SpriteRenderer>().sortingLayerName = "Enemy";
        HPBar = GetComponent<LineRenderer>();
        HPBar.useWorldSpace = false;
        HPBar.startWidth = 0.1f;
        HPBar.endWidth = 0.1f;
        HPBar.SetPosition(0, new Vector3(0, 1));
        HPBar.SetPosition(1, new Vector3(1, 1));
        HPBar.sortingLayerName = "Enemy";
        HPBar.startColor = Color.red;
        HPBar.endColor = Color.red;
        HPBar.sortingOrder = 10;
    }
    private void Start()
    {
        eating = gameObject.AddComponent<AudioSource>();
        eating.playOnAwake = false;
        eating.loop = true;
        eating.clip = gm.audio[6].clip;
        drinking = gameObject.AddComponent<AudioSource>();
        drinking.clip = gm.audio[5].clip;
        drinking.playOnAwake = false;
        drinking.loop = true;
        vect = Vector2.left;

        _enemyInvisible = enemyInvisible;
        _enemyPVO = enemyPVO;
        _enemyStrong = enemyStrong;
        numLater = gameObject.layer;
        _layer = LayerMask.LayerToName(numLater);

        InvokeRepeating(nameof(fire), 0.0f, damageRetryTime);
        InvokeRepeating(nameof(poison), 0.0f, timeBetweenDamage);
        InvokeRepeating(nameof(BattleEnemy), 0.0f, speedAttack);
    }
    private void Update()
    {

        if (change_params)
        {
            max_health *= health_m;
            health = max_health;
            damageEnemy *= damage_m;
            change_params = false;
        }
        if (change && changeTower)
        {
            gameObject.layer = LayerMask.NameToLayer("EnemyTower");
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            vect = Vector2.right;
        }

        if (change != gameObject.GetComponent<Debuff>().change) change = gameObject.GetComponent<Debuff>().change;

        if (health <= 0)
        {
            gm.audio[0].Play();
            GetComponent<LineRenderer>().Equals(false);
            anim.SetInteger("state", 2);   
        }

        if (!changeTower)
        {
            if (dbHp != gameObject.GetComponent<Debuff>().dbHp) dbHp = gameObject.GetComponent<Debuff>().dbHp;
            if (poisonDamage != gameObject.GetComponent<Debuff>().poisonDamage) poisonDamage = gameObject.GetComponent<Debuff>().poisonDamage;
            if (dbSpeed != gameObject.GetComponent<Debuff>().dbSpeed) dbSpeed = gameObject.GetComponent<Debuff>().dbSpeed;
            if (x3Damage != gameObject.GetComponent<Debuff>().x3Damage) x3Damage = gameObject.GetComponent<Debuff>().x3Damage;
            if (besiege != gameObject.GetComponent<Debuff>().besiege) besiege = gameObject.GetComponent<Debuff>().besiege;

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
                if (_speed + _dbSpeed <= 0)
                {
                    _speed = 0;
                    speed = 0;
                }
                else
                {
                    _speed += _dbSpeed;
                    speed += _dbSpeed;
                }
            }
            if (besiege)
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

            if (health <= 0) health = 0;

            HPBar.SetPosition(1, new Vector3(health / max_health, 1));
            if (cold && _speed == speed)
            {
                _speed /= decelerationIn;
                timeCold = Time.time + freezeTime;
                cold = false;
            }
            if (Time.time > timeCold && !stop && _damageEnemy == 0)
            {
                _speed = speed;
            }
            if (Fire)
            {
                if (xtime < Time.time)
                {
                    Fire = false;
                }
            }
        }

    }
    private void LateUpdate()
    {
        transform.Translate(vect * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!changeTower)
        {
            if (collision.gameObject.tag == "Castle")
            {
                gm.killedEnemies++;
                Destroy(gameObject);
            }
            if (!enemyPVO)
            {
                GetComponent<Animator>().SetInteger("state", 1);
                stop = true;
                if (collision.gameObject.tag == "TowerBuff" || collision.gameObject.tag == "TowerFreeze" || collision.gameObject.tag == "TowerDebuff")
                {
                    drinking.Play();
                }
                else eating.Play();
                _speed = 0;
            }
            if (collision.gameObject.layer == 11)
            {
                float __damageEnemy = collision.gameObject.GetComponent<Enemy>().damageEnemy;
                _damageEnemy += __damageEnemy;
                if (_damageEnemy > 0)
                {
                    HPBar.enabled = false;
                    GetComponent<Animator>().SetInteger("state", 1);
                    _speed = 0;
                }
            }
        }
        if (changeTower)
        {
            if ((collision.gameObject.layer == 6 || collision.gameObject.layer == 9) || collision.gameObject.layer == 10)
            {
                float __damageEnemy = collision.gameObject.GetComponent<Enemy>().damageEnemy;
                _damageEnemy += __damageEnemy;
                if (_damageEnemy > 0)
                {
                    HPBar.enabled = false;
                    GetComponent<Animator>().SetInteger("state", 1);
                    _speed = 0;
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!changeTower)
        {
            if (!enemyPVO)
            {
                GetComponent<Animator>().SetInteger("state", 0);
                stop = false;
                if (collision.gameObject.tag == "TowerBuff" || collision.gameObject.tag == "TowerFreeze" || collision.gameObject.tag == "TowerDebuff")
                {
                    drinking.Stop();
                }
                else eating.Stop();
                _speed = speed;
            }
            if (collision.gameObject.layer == 11)
            {
                float __damageEnemy = collision.gameObject.GetComponent<Enemy>().damageEnemy;
                _damageEnemy -= __damageEnemy;
                if (_damageEnemy == 0)
                {
                    GetComponent<Animator>().SetInteger("state", 0);
                    _speed = speed;
                }
            }
        }
        if (changeTower)
        {
            if ((collision.gameObject.layer == 6 || collision.gameObject.layer == 9) || collision.gameObject.layer == 10)
            {
                float __damageEnemy = collision.gameObject.GetComponent<Enemy>().damageEnemy;
                _damageEnemy -= __damageEnemy;
                if (_damageEnemy == 0)
                {
                    GetComponent<Animator>().SetInteger("state", 0);
                    _speed = speed;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!changeTower)
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
                else if ((Normal || Splash) && Strong) health -= damageTower;
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
            if (Invisible && !Freeze && !enemyPVO)
            {
                if ((!PVO || (PVO && Normal)) && !enemyStrong) health -= damageTower;
                else if ((Normal || Splash) && Strong) health -= damageTower;
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
    void BattleEnemy()
    {
        health -= _damageEnemy;
    }

    public void die()
    {
        gold = gold + ((gold / 100) * (percentOfEnemy * gm.gold5B));
        gm.gold += gold;
        gm.killedEnemies++;
        Destroy(gameObject);
    }



}
