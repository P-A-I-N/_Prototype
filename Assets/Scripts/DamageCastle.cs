using UnityEngine;

public class DamageCastle : MonoBehaviour
{
    public float health = 10;
    public GameObject gameOver;
    GameMap gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
    }
        void LateUpdate()
    {
        if (health <= 0)
        {
            gm.audio[4].Play();
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
