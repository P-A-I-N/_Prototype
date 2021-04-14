using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string scene;

    public void Game()
    {
        Application.LoadLevel(scene);
    }

    public void Setting()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
