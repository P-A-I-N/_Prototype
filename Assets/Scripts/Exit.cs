
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}