using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private float _speed;
    public float health;
    GameMap gm;

    private void Awake()
    {
        _speed = speed;
        //gm = GetComponentInParent<GameMap>();
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
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

        _speed = 0;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
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
    }
}
