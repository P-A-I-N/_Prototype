using UnityEngine;
using UnityEngine.UI;

public class TowerTank : MonoBehaviour
{
    public int health = 10;
    public int price;
    public GameObject levelUp;
    public Text nameTower;
    private float _health;
    private bool damage;
    private int num_enemies = 0;


    private void Awake()
    {
        _health = health;
    }
    void LateUpdate()
    {
        if (damage)
        {
            _health -= 0.01f * num_enemies;
        }

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        num_enemies++;
        damage = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        num_enemies--;
        if (num_enemies <= 0) damage = false;
    }
}
