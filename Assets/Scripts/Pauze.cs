using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pauze : MonoBehaviour
{
    public int speed = 3;
    public GameObject panel;
    public GameObject bmuz;
    public GameObject bsound;
    bool actmuz = false;
    bool actsound = false;
    GameMap gm;
    private void Awake()
    {
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
    }
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
        Time.timeScale = speed;
    }
    public void pausetime()
    {
        Time.timeScale = 0;
    }
    public void normaltime()
    {
        Time.timeScale = 1;
    }
    public void buttonmuz()
    {

        if (actmuz == false)
        {
            gm.audio[3].mute = true;
            bmuz.GetComponent<Image>().color = Color.gray;
            actmuz = true;
        }
        else
        {
            gm.audio[3].mute = false;
            bmuz.GetComponent<Image>().color = Color.white;
            actmuz = false;
        }
    }
    public void buttonsoung()
    {
        if (actsound == false)
        {
            for (int i = 0; i < gm.audio.Length; i++)
            {

                if(i != 3)gm.audio[i].mute = true;
            }
            bsound.GetComponent<Image>().color = Color.gray;
            actsound = true;

        }
        else
        {
            for (int i = 0; i < gm.audio.Length; i++)
            {

                if (i != 3) gm.audio[i].mute = false;
            }
            bsound.GetComponent<Image>().color = Color.white;
            actsound = false;
        }
    }
}

