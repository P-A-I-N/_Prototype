using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    private float _speed;
    public float health = 10;
    public bool damage;
    public float levelDamage = 0.01f;
    private void Awake()
    {
        _speed = speed;
    }
    void Update()
    {
        
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

    //private void LateUpdate()
    //{
    //    if(damage)
    //    {
    //        health-=levelDamage;
    //    }

    //    if (health <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "AttackRangeTower1")
    //    {
    //        damage = true;
    //    }

    //    if (other.gameObject.tag == "AttackRangeTower2")
    //    {
    //        damage = true;
    //        levelDamage += 0.01f;
    //    }

    //    if (other.gameObject.tag == "AttackRangeTower3")
    //    {
    //        damage = true;
    //        levelDamage += 0.04f;
    //    }

    //}
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "AttackRangeTower1")
    //    {
    //        damage = true;
    //    }

    //    if (other.gameObject.tag == "AttackRangeTower2")
    //    {
    //        damage = true;
    //    }

    //    if (other.gameObject.tag == "AttackRangeTower3")
    //    {
    //        damage = true;
    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "AttackRangeTower1")
    //    {
    //        damage = false;
    //    }

    //    if (other.gameObject.tag == "AttackRangeTower2")
    //    {
    //        damage = false;
    //        levelDamage -= 0.01f;
    //    }

    //    if (other.gameObject.tag == "AttackRangeTower3")
    //    {
    //        damage = false;
    //        levelDamage -= 0.04f;
    //    }

    //}
}
