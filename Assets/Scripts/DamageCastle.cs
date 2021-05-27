using UnityEngine;

public class DamageCastle : MonoBehaviour
{
    public float health = 10;
    public GameObject gameOver; 

    void LateUpdate()
    {
        if (health <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health --;
    }
}
