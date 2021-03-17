using UnityEngine;

public class DamageCastle : MonoBehaviour
{
    public float health = 10;
    public GameObject gameOver; 
    public GameObject button;

    void LateUpdate()
    {
        if (health <= 0)
        {
            button.SetActive(false);
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
