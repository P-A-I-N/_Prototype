using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private float _speed;
    public float health = 10;

    private void Awake()
    {
        _speed = speed;
    }
    void LateUpdate()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
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
        if (collision.tag == "Bullet")
        {
            health--;
        }
    }
}
