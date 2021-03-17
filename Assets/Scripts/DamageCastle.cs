using UnityEngine;

public class DamageCastle : MonoBehaviour
{
    public float health = 10;
    public GameObject GameOver; 
    public GameObject Button;

    void LateUpdate()
    {
        if (health <= 0)
        {
            Button.SetActive(false);
            GameOver.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health --;
    }
}
