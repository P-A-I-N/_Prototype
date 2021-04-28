using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private float _speed;
    public float health;
    public float max_health;
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
    LineRenderer HPBar;

    public bool enemyStrong;
    public bool enemyPVO;
    public bool enemyInvisible;

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
    private void Update()
    {
        HPBar.SetPosition(1, new Vector3(-0.5f + health / max_health, 0.8f));
        if (debuff && !_debuff)
        {
            health -= debuffHp;
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
        if (Time.time > timeCold && !stop)
        {
            _speed = speed;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            gm.gold += gold;
        }

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



        if ((Normal || Splash) && !Invisible && !enemyPVO && !enemyStrong && !enemyInvisible)
        {
            health--;
        }
        if ((PVO) && enemyPVO && !enemyStrong && !enemyInvisible)
        {
            health--;
        }
        if (!Invisible && Freeze && !enemyPVO && !enemyInvisible)
        {
            if (!enemyStrong)
            {
                health--;
                cold = true;
            }
            else
            {
                cold = true;
            }
        }
        if (Invisible && !Freeze && (!PVO || (PVO && Normal)) && !enemyStrong && !enemyPVO)
        {
            health--;
        }
        if (Invisible && Freeze && !enemyPVO)
        {
            if (!enemyStrong)
            {
                health--;
                cold = true;
            }
            else
            {
                cold = true;
            }
        }
        if (collision.tag == "TowerDebuff")
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
