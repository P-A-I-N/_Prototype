using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private float _speed;
    public float health;
    public float coldTime;
    public float decelerationIn;
    public int debuffHp;
    public int gold;
    GameMap gm;
    bool cold;
    float timeCold;
    bool stop;
    bool debuff;
    bool _debuff;

    private void Awake()
    {
        _speed = speed;
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
    }
    private void Update()
    {
        if(debuff && !_debuff)
        {
            health -=debuffHp;
            _debuff = true;
        }
        if (!debuff && _debuff)
        {
            health += debuffHp;
            _debuff = false;
        }
        if (cold && _speed == speed)
        {
            _speed /= decelerationIn;
            timeCold = Time.time + coldTime;
            cold = false;
        }
        if(Time.time > timeCold && !stop)
        {
            _speed = speed;
        }  
        
        if(health <= 0)
        {
            Destroy(gameObject);
            gm.gold += gold;
        }
        
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Castle")
        {
            Destroy(gameObject);
        }
        stop = true;
        _speed = 0;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        stop = false;
        _speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((((collision.tag == "Bullet" || collision.tag == "InvisibleBullet") || collision.tag == "InvisibleBulletSplash") || collision.tag == "BulletSplash") && gameObject.tag == "Enemy")
        {
            health--;
        }
        if ((collision.tag == "BulletPVO" || collision.tag == "InvisibleBulletPVO") && gameObject.tag == "EnemyVO")
        {
            health--;
        }
        if ((collision.tag == "BulletCold" || collision.tag == "InvisibleBulletFreeze") && gameObject.tag == "Enemy")
        {
            health--;
            cold = true;
        }
        if ((collision.tag == "InvisibleBullet" || collision.tag == "InvisibleBulletSplash") && gameObject.tag == "EnemyInvisible")
        {
            health--;
        }
        if (collision.tag == "InvisibleBulletFreeze" && gameObject.tag == "EnemyInvisible")
        {
            health--;
            cold = true;
        }
        if(collision.tag == "TowerDebuff")
        {
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
}
