using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private float _speed;
    public float health;
    public float coldTime;
    public float decelerationIn;
    GameMap gm;
    bool cold;
    float timeCold;
    bool stop;

    private void Awake()
    {
        _speed = speed;
        //gm = GetComponentInParent<GameMap>();
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
    }
    private void Update()
    {
        if(cold && _speed == speed)
        {
            _speed /= decelerationIn;
            timeCold = Time.time + coldTime;
            cold = false;
        }
        if(Time.time > timeCold && !stop)
        {
            _speed = speed;
        }
    }
    void LateUpdate()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            gm.gold += 50;
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
        if ( collision.tag == "Bullet" && gameObject.tag == "Enemy")
        {
            health--;
        }
        if ( collision.tag == "BulletPVO" && gameObject.tag == "EnemyVO")
        {
            health--;
        }
        if (collision.tag == "BulletCold" && gameObject.tag == "Enemy")
        {
            health--;
            cold = true;
        }
    }
}
