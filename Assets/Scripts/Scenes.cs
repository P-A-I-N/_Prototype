 
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void NextScene(int numScene)
    {
        SceneManager.LoadScene(numScene);
    }
}
