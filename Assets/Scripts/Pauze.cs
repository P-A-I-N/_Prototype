using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauze : MonoBehaviour
{
    public string scene;
    public GameObject panel;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
            {
                panel.SetActive(true);
                Time.timeScale = 0;
            }
            else if (Time.timeScale <= 0)
            {
                panel.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    public void _pauze()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void exit()
    {
        Application.Quit();
    }
    public void menu()
    {
        Application.LoadLevel(scene);
    }
}
