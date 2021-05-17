using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed;
    public Transform parent;
    public float parentPos;
    public float pos;
    public float x;
    public int rangeSplash;
    public float damageTower;

    public bool Fire;
    public bool SplashFreeze;
    public bool Splash;
    public bool Freeze;
    public bool Invisible;
    public bool PVO;
    public bool Strong;
    public bool Normal;

    public string tipe;
    public string lvl;

    public int numSplashFreeze;

    public float freezeTime;
    public float decelerationIn;


    private void Start()
    {
        damageTower += GetComponentInParent<Tower>().damageTower;
        if (GetComponentInParent<Tower>().strongBuff == true) Strong = true;
    }
    private void Update()
    {
        if (Splash)
        {
            x = parentPos + rangeSplash;
            pos = transform.position.x;
            if (pos > x)
            {
                Destroy(gameObject);
            }
            if (Freeze && parent != null)
            {
                SplashFreeze = true;
            }
        }
    }
    void LateUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool enemyStrong = collision.gameObject.GetComponent<Enemy>().enemyStrong;
        bool enemyPVO = collision.gameObject.GetComponent<Enemy>().enemyPVO;
        bool enemyInvisible = collision.gameObject.GetComponent<Enemy>().enemyInvisible;



        if ((!PVO || (Normal && PVO)) && !Splash && !enemyPVO && !enemyInvisible)
        {
            Destroy(gameObject);
        }
        if (PVO && enemyPVO && !Splash)
        {
            Destroy(gameObject);
        }
        if (Invisible && !Splash && (!PVO || (Normal && PVO)) && !enemyPVO)
        {
            Destroy(gameObject);
        }
        if (Splash)
        {
            if (Freeze)
            {
                if (enemyStrong)
                {
                    Destroy(gameObject);
                }
                else if (parent == null)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    parent = collision.transform;
                    parentPos = parent.position.x;
                    speed *= 10;
                }
            }
            if (enemyPVO && PVO)
            {
                if (!enemyPVO)
                {
                    Destroy(gameObject);
                }
                else if (parent == null)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    parent = collision.transform;
                    parentPos = parent.position.x;
                    speed *= 10;
                }
            }
            if (!enemyPVO && !enemyInvisible && !Invisible && !Freeze)
            {
                if (enemyStrong)
                {
                    Destroy(gameObject);
                }
                else if (parent == null)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    parent = collision.transform;
                    parentPos = parent.position.x;
                    speed *= 10;
                }
            }
            if (!enemyPVO && Invisible)
            {
                if (enemyStrong)
                {
                    Destroy(gameObject);
                }
                else if (parent == null)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    parent = collision.transform;
                    parentPos = parent.position.x;
                    speed *= 10;
                }
            }
        }
    }
}
