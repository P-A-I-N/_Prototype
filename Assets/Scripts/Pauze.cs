using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauze : MonoBehaviour
{
    public GameObject panel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
            {
                stop();
            }
            else if (Time.timeScale <= 0)
            {
                start();
            }
        }
    }
    public void stop()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void start()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1;
    }
    public void menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void speedtime()
    {
        Time.timeScale = 3;
    }
    public void pausetime()
    {
        Time.timeScale = 0;
    }
    public void normaltime()
    {
        Time.timeScale = 1;
    }
}

